using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HashCode.App.Application
{
    public class Solution : ISolution
    {
        private readonly ILogger<Solution> _logger;
        private readonly IStatementsProvider<ProblemStatement> _statementsProvider;
        private readonly IResolver<ProblemStatement, Result> _resolver;
        private readonly IResultFileGenerator<Result> _resultFileGenerator;

        public Solution(
            ILogger<Solution> logger,
            IStatementsProvider<ProblemStatement> statementsProvider,
            IResolver<ProblemStatement, Result> resolver,
            IResultFileGenerator<Result> resultFileGenerator
            )
        {
            _logger = logger;
            _statementsProvider = statementsProvider;
            _resolver = resolver;
            _resultFileGenerator = resultFileGenerator;
        }

        public async Task Calculate()
        {
            var statement = await _statementsProvider.GetProblemStatement();
            var result = await _resolver.Resolve(statement);
            await _resultFileGenerator.Generate(result);
            _logger.LogInformation("Problem solved");
        }
    }
}
