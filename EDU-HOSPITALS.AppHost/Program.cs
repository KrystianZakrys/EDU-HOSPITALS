using Aspire.Customization.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

var rabbitmq = builder.AddRabbitMQ("messaging")
    .WithManagementPlugin();

var kafka = builder.AddKafka("kafka")
    .WithKafkaUI();

var cache = builder.AddRedis("cache")
    .WithRedisInsight()
    .WithRedisCommander();



builder.AddProject<Projects.APIGateway>("apigateway").WithReplicas(3);

builder.AddProject<Projects.PatientCard_API>("patientcardAPI")
    .WithScalar()
    .WithReference(rabbitmq)
    .WithReference(kafka);

builder.AddProject<Projects.Emergency_API>("emergencyAPI")
    .WithScalar()
    .WithReference(rabbitmq)
    .WithReference(kafka);

builder.AddProject<Projects.Clinics_API>("clinicsAPI")
    .WithScalar()
    .WithReference(rabbitmq)
    .WithReference(kafka);

builder.AddProject<Projects.Hospitals_API>("hospitalsAPI")
    .WithScalar()
    .WithReference(rabbitmq)
    .WithReference(kafka);



builder.Build().Run();
