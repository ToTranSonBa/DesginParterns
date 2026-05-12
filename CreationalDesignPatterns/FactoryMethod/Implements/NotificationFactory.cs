using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Implements
{
    public abstract class NotificationFactory
    {
        public abstract INotification Create();

        public void Notify(string message)
        {
            var notification = Create();
            notification.Send(message);
        }
    }
}
