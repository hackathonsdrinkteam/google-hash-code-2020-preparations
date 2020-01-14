using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HashCode.App.Application
{
    public class ResultFileGenerator : IResultFileGenerator<Result>
    {
        private readonly ILogger<ResultFileGenerator> _logger;

        public ResultFileGenerator(ILogger<ResultFileGenerator> logger)
        {
            _logger = logger;
        }

        public async Task Generate(Result result)
        {
            _logger.LogInformation("File generated");
        }
    }
}
