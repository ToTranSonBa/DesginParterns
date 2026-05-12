using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Implements
{
    public class BaseCoffee : ICoffee
    {
        public double GetCost()
        {
            return 5.0; // Base cost of the coffee
        }
        public string GetDescription()
        {
            return "Base Coffee"; // Description of the coffee
        }
    }
}
