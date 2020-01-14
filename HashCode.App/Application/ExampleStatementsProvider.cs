using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HashCode.App.Application
{
    public class ExampleStatementsProvider : IStatementsProvider<ProblemStatement>
    {
        private readonly ILogger<ExampleStatementsProvider> _logger;

        public ExampleStatementsProvider(ILogger<ExampleStatementsProvider> logger)
        {
            _logger = logger;
        }

        public async Task<Dictionary<string, ProblemStatement>> GetStatements()
        {
            var statements =  await Task.FromResult(new Dictionary<string, ProblemStatement> { { "a_example.in", new ProblemStatement(17, 4, new List<int> { 2, 5, 6, 8 }) } });
            _logger.LogInformation("Files prepared");
            return statements;
        }
    }
}
