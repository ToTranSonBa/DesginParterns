using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Implements
{
    public class EmailFactory : NotificationFactory
    {
        public override INotification Create()
        {
            return new EmailNotification();
        }
    }
}
