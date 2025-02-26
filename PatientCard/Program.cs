using Microsoft.AspNetCore.Authentication.Negotiate;
using MongoDB.Driver;
using OpenTelemetry.Trace;
using PatientCard.Domain.Entities;
using PatientCard.Domain.Repositories;
using PatientCard.Infrastructure.Repositories;
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


// MongoDB configuration
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var settings = new MongoClientSettings
    {
        Server = new MongoServerAddress("localhost", 27017), // MongoDB server settings
    };
    return new MongoClient(settings);
});

builder.Services.AddScoped(sp =>
{
    var mongoClient = sp.GetRequiredService<IMongoClient>();

    return mongoClient.GetDatabase("clinics");
});

builder.Services.AddScoped<IPatientCardHistoryRepository<PatientCardHistory>, PatientCardRepository>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//   .AddNegotiate();

//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy.
//    options.FallbackPolicy = options.DefaultPolicy;
//});

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
