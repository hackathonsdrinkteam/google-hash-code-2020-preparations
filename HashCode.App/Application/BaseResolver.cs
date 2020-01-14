using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HashCode.App.Application
{
    public class BaseResolver : IResolver<ProblemStatement, Result>
    {
        protected readonly ILogger<BaseResolver> _logger;

        public BaseResolver(ILogger<BaseResolver> logger)
        {
            _logger = logger;
        }
        public virtual async Task<Result> Resolve(ProblemStatement input)
        {
            _logger.LogInformation("resolved");
            return await Task.FromResult(new Result(new List<int> { 0, 1, 2, 3 }));
        }
    }
}
