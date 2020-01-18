using System.Collections.Generic;
using System.Linq;

namespace HashCode.App.Models
{
    public class ProblemStatement
    {
        public ProblemStatement(int maximumNumberOfSlices, int pizzaTypesAmount, List<int> pizzaTypes)
        {
            MaximumNumberOfSlices = maximumNumberOfSlices;
            PizzaTypesAmount = pizzaTypesAmount;
            PizzaTypes = pizzaTypes.Select((slices, index) => new PizzaType(index, slices)).ToList();
        }
        public int MaximumNumberOfSlices { get; private set; }
        public int PizzaTypesAmount { get; private set; }
        public List<PizzaType> PizzaTypes { get; private set; }
    }
}
