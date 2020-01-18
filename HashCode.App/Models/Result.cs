using System.Collections.Generic;

namespace HashCode.App.Models
{
    public class Result
    {
        public Result(List<int> resultItems)
        {
            Items = resultItems;
        }
        public List<int> Items { get; private set; }
    }
}
