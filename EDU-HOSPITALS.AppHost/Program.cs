using Aspire.Customization.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PatientCard_API>("patientcardAPI").WithScalar();

builder.AddProject<Projects.Emergency_API>("emergencyAPI").WithScalar();

builder.AddProject<Projects.Clinics_API>("clinicsAPI").WithScalar();

builder.AddProject<Projects.Hospitals_API>("hospitalsAPI").WithScalar();

builder.Build().Run();
