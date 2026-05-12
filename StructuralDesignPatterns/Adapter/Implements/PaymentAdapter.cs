using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Implements
{
    public class PaymentAdapter : IPaymentProcessor
    {
        private readonly LegacyPaymentGateway _legacyPayment;
        public PaymentAdapter(LegacyPaymentGateway legacyPayment) 
        { 
            _legacyPayment = legacyPayment;
        }
        public void Pay(decimal amount)
        {
            _legacyPayment.MakePayment(amount.ToString("F2"));
        }
    }
}
