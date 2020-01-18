using HashCode.App.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HashCode.App.Application.Participants
{
    public class MDWResolver : BaseResolver
    {
        public MDWResolver(ILogger<BaseResolver> logger) : base(logger) { }
        public override Task<Result> Resolve(ProblemStatement input)
        {
            _logger.LogInformation("MDW Resolver");
            return base.Resolve(input);
        }
    }
}
