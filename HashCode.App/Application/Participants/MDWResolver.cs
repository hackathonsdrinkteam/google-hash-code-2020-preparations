using HashCode.App.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HashCode.App.Application.Participants
{
    public class MDWResolver : BaseResolver
    {
        public MDWResolver(ILogger<BaseResolver> logger) : base(logger) { }
        public override async Task<Result> Resolve(ProblemStatement input)
        {
            var stopWatch = Stopwatch.StartNew();
            var smallestPizza = input.PizzaTypes.Select(type => type.Slices).Min();
            var maxSlices = input.MaximumNumberOfSlices;
            var pizzas = input.PizzaTypes;
            var currentSlices = 0;
            var orderedPizzas = new List<int>();
            while (currentSlices< maxSlices)
            {
                var pizzaToUse = pizzas.Where(pizza => pizza.Slices <= maxSlices - currentSlices).LastOrDefault();
                if(pizzaToUse is null)
                {
                    break;
                }
                pizzas.Remove(pizzaToUse);
                orderedPizzas.Add(pizzaToUse.Type);
                currentSlices += pizzaToUse.Slices;
            }
            var result = await Task.FromResult(new Result(orderedPizzas));
            _logger.LogInformation("Resolved by MDW in {0}s", (float)stopWatch.ElapsedMilliseconds / 1000);
            _logger.LogInformation("Rest is {0} slices when smallest item in set is {1}", maxSlices - currentSlices, smallestPizza);
            return result;
        }
    }
}
