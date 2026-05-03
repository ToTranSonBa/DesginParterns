
using StrategyDesignPattern.Implements.ConcreteStrategy;
using StrategyDesignPattern.Implements.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern
{
    class Program
    {
        public static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"Payment {i}:");
                    var context = new PaymentContext(new MomoPayment());
                    context.ExecutePayment(100);
                }
                else
                {
                    Console.WriteLine($"Payment {i}:");
                    var context = new PaymentContext(new BankPayment());
                    context.ExecutePayment(200);
                }
            }
        }
    }
}
