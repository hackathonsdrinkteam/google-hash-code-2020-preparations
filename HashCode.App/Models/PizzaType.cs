using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode.App.Models
{
    public class PizzaType
    {
        public PizzaType(int type, int slices)
        {
            Type = type;
            Slices = slices;
        }
        public int Type { get; private set; }
        public int Slices { get; private set; }
    }
}
