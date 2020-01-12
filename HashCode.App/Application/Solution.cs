using HashCode2020PreparationsApp.Interfaces;
using HashCode2020PreparationsApp.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HashCode2020PreparationsApp.Application
{
    public class Solution: ISolution
    {
        private readonly IStatementsProvider<ProblemStatement> _statementsProvider;
        private readonly ILogger<Solution> _logger;

        public Solution(IStatementsProvider<ProblemStatement> statementsProvider, ILogger<Solution> logger)
        {
            _statementsProvider = statementsProvider;
            _logger = logger;
        }

        public async Task Calculate()
        {
           var statements = await _statementsProvider.GetStatements();
           _logger.LogInformation("Statement loaded, it has {0} pizza types", statements["a_example.in"].PizzaTypes);
        }
    }
}
