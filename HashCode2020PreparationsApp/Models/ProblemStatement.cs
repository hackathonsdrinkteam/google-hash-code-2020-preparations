using System.Collections.Generic;

namespace HashCode2020PreparationsApp.Models
{
    public class ProblemStatement
    {
        public ProblemStatement(int maximumNumberOfSlices, int pizzaTypesAmount, List<int> pizzaTypes)
        {
            MaximumNumberOfSlices = maximumNumberOfSlices;
            PizzaTypesAmount = pizzaTypesAmount;
            PizzaTypes = pizzaTypes;
        }
        public int MaximumNumberOfSlices { get; private set; }
        public int PizzaTypesAmount { get; private set; }
        public List<int> PizzaTypes { get; private set; }
    }
}
