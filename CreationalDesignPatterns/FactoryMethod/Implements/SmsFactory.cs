using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Implements
{
    public class SmsFactory : NotificationFactory
    {
        public override INotification Create()
        {
            return new SmsNotification();
        }
    }
}
