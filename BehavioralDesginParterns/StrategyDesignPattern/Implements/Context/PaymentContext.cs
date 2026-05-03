using StrategyDesignPattern.Implements.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern.Implements.Context
{
    public class PaymentContext
    {
        private readonly IPayments _paymentStrategy;
        public PaymentContext(IPayments paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }
        public void ExecutePayment(decimal amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }
}
