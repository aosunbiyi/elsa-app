using System.Threading.Tasks;
using Elsa;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ElsaQuickstarts.ConsoleApp.HelloWorld
{
    class Program
    {
        private static async Task Main()
        {
            var host = new HostBuilder()
              .ConfigureServices(ConfigureServices)
              .UseConsoleLifetime()
              .Build();

            using (host)
            {
                await host.StartAsync();
                await host.WaitForShutdownAsync();
            }
        }

        private static void ConfigureServices(IServiceCollection services) =>
            services
                .AddElsa(elsa => elsa
                    .AddConsoleActivities()
                    .AddQuartzTemporalActivities()
                    .AddWorkflow<RecurringTaskWorkflow>());
    }
}
