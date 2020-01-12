using HashCode2020PreparationsApp.Interfaces;
using HashCode2020PreparationsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HashCode2020PreparationsApp.Application
{
    public class ExampleStatementsProvider : IStatementsProvider<ProblemStatement>
    {
        public async Task<Dictionary<string, ProblemStatement>> GetStatements()
        {
            return await Task.FromResult(new Dictionary<string, ProblemStatement> { { "a_example.in", new ProblemStatement(17, 4, new List<int> { 2, 5, 6, 8 }) } });
        }
    }
}
