var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.AddServiceDefaults();
var app = builder.Build();

app.MapReverseProxy();

app.Run();
