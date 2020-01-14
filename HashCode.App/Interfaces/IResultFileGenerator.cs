using System.Threading.Tasks;

namespace HashCode.App.Interfaces
{
    public interface IResultFileGenerator<TResult>
    {
        public Task Generate(TResult result);
    }
}
