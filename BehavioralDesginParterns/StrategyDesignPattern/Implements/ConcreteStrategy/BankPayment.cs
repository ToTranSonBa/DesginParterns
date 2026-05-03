using StrategyDesignPattern.Implements.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern.Implements.ConcreteStrategy
{
    public class BankPayment : IPayments
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount} using Bank Payment.");
        }
    }
}
