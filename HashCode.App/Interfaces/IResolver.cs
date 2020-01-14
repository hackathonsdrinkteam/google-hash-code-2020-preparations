using System.Threading.Tasks;

namespace HashCode.App.Interfaces
{
    public interface IResolver<TInput, TResult>
    {
        Task<TResult> Resolve(TInput input);
    }
}
