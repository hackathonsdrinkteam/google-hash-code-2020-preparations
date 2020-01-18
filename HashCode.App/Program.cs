using HashCode.App.Application;
using HashCode.App.Application.Participants;
using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace HashCode.App
{
    class Program
    {
        static async Task Main()
        {
            var serviceProvider = GetServiceProvider(GetConfiguration());
            var logger = GetLogger(serviceProvider);
            logger.LogInformation("Starting application");
            var solutionWatch = Stopwatch.StartNew();
            var solution = serviceProvider.GetService<ISolution>();
            await solution.Calculate();
            logger.LogInformation("All done in {0}s", (float)solutionWatch.ElapsedMilliseconds / 1000);
        }

        private static ServiceProvider GetServiceProvider(IConfiguration configuration)
        {
            var appConfig = new ApplicationConfig();
            configuration.Bind("ApplicationConfig", appConfig);
            var serviceCollection = new ServiceCollection()
               .AddLogging(options =>
               {
                   options.AddConsole();
                   options.SetMinimumLevel(LogLevel.Debug);
               })
               .AddSingleton(appConfig)
               .AddSingleton<IStatementsProvider<ProblemStatement>, FileStatementsProvider>()
               .AddSingleton<IResolver<ProblemStatement, Result>, BaseResolver>()
               .AddSingleton<IResultFileGenerator<Result>, ResultFileGenerator>()
               .AddSingleton<ISolution, Solution>();
            switch (appConfig.ResolverInstancePrefix)
            {
                case "MDW":
                    serviceCollection.AddSingleton<IResolver<ProblemStatement, Result>, MDWResolver>();
                    break;
                default:
                    serviceCollection.AddSingleton<IResolver<ProblemStatement, Result>, BaseResolver>();
                    break;
                        
            }
            return serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<Program>();
            return builder.Build();
        }
        private static ILogger<Program> GetLogger(ServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
        }
    }
}
