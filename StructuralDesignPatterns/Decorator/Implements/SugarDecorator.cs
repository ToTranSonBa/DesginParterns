using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Implements
{
    public class SugarDecorator : ICoffee
    {
        private readonly ICoffee _coffee;
        public SugarDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }
        public double GetCost()
        {
            return _coffee.GetCost() + 0.5; // Adding cost of sugar
        }
        public string GetDescription()
        {
            return _coffee.GetDescription() + ", Sugar";
        }
    }
}
