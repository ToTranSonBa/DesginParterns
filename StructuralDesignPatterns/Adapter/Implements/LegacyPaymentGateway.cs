using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Implements
{
    public class LegacyPaymentGateway
    {
        public void MakePayment(string value)
        {
            Console.WriteLine($"Legacy paid {value}");
        }
    }
}
