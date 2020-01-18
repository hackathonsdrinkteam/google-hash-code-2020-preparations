using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
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
            var stopWatch = Stopwatch.StartNew();
            var result = await Task.FromResult(new Result(new List<int> { 0, 2, 3 }));
            _logger.LogInformation("Resolved in {0}s", (float)stopWatch.ElapsedMilliseconds / 1000);
            return result;
        }
    }
}
