using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.Implements
{
    public abstract class Colleague(IMediator mediator)
    {
        protected IMediator Mediator { get; } = mediator;

        public void Send(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty");
            Mediator.Send(message, this);
        }
        public abstract void Receive(string message);
    }
}
