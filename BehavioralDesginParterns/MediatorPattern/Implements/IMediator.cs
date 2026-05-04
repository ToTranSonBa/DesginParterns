using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.Implements
{
    public interface IMediator
    {
        void Send(string message, Colleague sender);
    }
}
