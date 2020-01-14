using HashCode.App.Application;
using HashCode.App.Application.Participants;
using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HashCode.App
{
    class Program
    {
        static async Task Main()
        {
            var serviceProvider = GetServiceProvider();
            var logger = GetLogger(serviceProvider);
            logger.LogInformation("Starting application");
            var solutionWatch = Stopwatch.StartNew();
            var solution = serviceProvider.GetService<ISolution>();
            await solution.Calculate("a_example.in");
            logger.LogInformation("All done in {0}", (float)solutionWatch.ElapsedMilliseconds / 1000);
        }

        static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
               .AddLogging(options =>
               {
                   options.AddConsole();
                   options.SetMinimumLevel(LogLevel.Debug);
               })
               .AddSingleton<IStatementsProvider<ProblemStatement>, ExampleStatementsProvider>()
               .AddSingleton<IResolver<ProblemStatement, Result>, BaseResolver>()
               .AddSingleton<IResultFileGenerator<Result>, ResultFileGenerator>()
               .AddSingleton<ISolution, Solution>()
               .BuildServiceProvider();
        }

        static ILogger<Program> GetLogger(ServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
        }
    }
}
