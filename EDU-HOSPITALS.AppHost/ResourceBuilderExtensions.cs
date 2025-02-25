using System.Diagnostics;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Aspire.Customization.AppHost;


internal static class ResourceBuilderExtensions
{
    public static IResourceBuilder<T> WithScalar<T>(this IResourceBuilder<T> builder) where T: IResourceWithEndpoints
    {
        return builder.WithCommand("scalar-docs", "Scalar API Documentation", executeCommand: async _ =>
        {
            try
            {
                var endpoint = builder.GetEndpoint("https");
                var url = $"{endpoint.Url}/scalar/v1";
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                return new ExecuteCommandResult { Success = true };
            }
            catch (Exception ex) {
                return new ExecuteCommandResult { Success = false, ErrorMessage = ex.ToString() };
            }
        },
        updateState: context => context.ResourceSnapshot.HealthStatus == HealthStatus.Healthy ? ResourceCommandState.Enabled : ResourceCommandState.Disabled
        );
    }
}

