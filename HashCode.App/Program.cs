using HashCode.App.Application;
using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HashCode.App
{
    class Program
    {
        static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(options =>
                {
                    options.AddConsole();
                    options.SetMinimumLevel(LogLevel.Debug);
                })
                .AddSingleton<IStatementsProvider<ProblemStatement>, ExampleStatementsProvider>()
                .AddSingleton<ISolution, Solution>()
                .BuildServiceProvider();
            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");
            var solution = serviceProvider.GetService<ISolution>();
            await solution.Calculate();
            logger.LogDebug("All done!");
        }
    }
}
