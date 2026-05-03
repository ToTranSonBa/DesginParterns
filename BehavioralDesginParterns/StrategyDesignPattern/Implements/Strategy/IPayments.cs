using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern.Implements.Strategy
{
    public interface IPayments
    {
        void Pay(decimal amount);
    }
}
