using System.Collections.Generic;
using System.Threading.Tasks;

namespace HashCode.App.Interfaces
{
    public interface IStatementsProvider<T> where T : class
    {
        public Task<Dictionary<string, T>> GetStatements();
    }
}
