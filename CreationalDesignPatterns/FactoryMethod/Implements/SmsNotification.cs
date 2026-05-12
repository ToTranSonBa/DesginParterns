using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Implements
{
    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS Notification: {message}");
        }
    }
}
