using System.Collections.Generic;

namespace HashCode.App.Models
{
    public class Result
    {
        public Result(List<int> resultItems)
        {
            items = resultItems;
        }
        public List<int> items { get; private set; }
    }
}
