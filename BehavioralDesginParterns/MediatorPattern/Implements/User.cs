using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.Implements
{
    public class User(IMediator mediator, string name) : Colleague(mediator)
    {
        public string Name { get; set; } = name;

        public override void Receive(string message)
        {
            Console.WriteLine($"{Name} receives: {message}");
        }

    }
}
