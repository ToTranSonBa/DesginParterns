using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Implements
{
    public class MilkDecorator : ICoffee
    {
        private readonly ICoffee _coffee;
        public MilkDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public double GetCost()
        {
            return _coffee.GetCost() + 1;
        }

        public string GetDescription()
        {
            return _coffee.GetDescription() + ", Milk";
        }
    }
}
