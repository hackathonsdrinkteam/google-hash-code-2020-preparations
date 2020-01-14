using System.Threading.Tasks;

namespace HashCode.App.Interfaces
{
    public interface ISolution
    {
        Task Calculate(string fileToCalculate);
    }
}
