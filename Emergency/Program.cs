using Microsoft.AspNetCore.Authentication.Negotiate;
using OpenTelemetry.Trace;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Ustaw minimalny poziom logowania
    .WriteTo.Console() // Loguj do konsoli
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Loguj do pliku
    .CreateLogger();

builder.Host.UseSerilog(); // U¿yj Serilog jako loggera

// Dodaj OpenTelemetry
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing =>
    {
        tracing
            .AddAspNetCoreInstrumentation() // Automatyczne instrumentowanie ASP.NET Core
            .AddHttpClientInstrumentation() // Instrumentowanie klienta HTTP
            .AddConsoleExporter(); // Dodaj eksportera do konsoli
    });


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
