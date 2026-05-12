using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Implements
{
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email Notification: {message}");
        }
    }
}
