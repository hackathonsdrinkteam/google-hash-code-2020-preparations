using HashCode.App.Interfaces;
using HashCode.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HashCode.App.Application
{
    public class ExampleStatementsProvider : IStatementsProvider<ProblemStatement>
    {
        public async Task<Dictionary<string, ProblemStatement>> GetStatements()
        {
            return await Task.FromResult(new Dictionary<string, ProblemStatement> { { "a_example.in", new ProblemStatement(17, 4, new List<int> { 2, 5, 6, 8 }) } });
        }
    }
}
