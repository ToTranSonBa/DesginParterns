using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.Implements
{
    public interface IObserver
    {
        void Update(string message);
    }

    public class ConcreteObserver : IObserver
    {
        private string _name;
        public ConcreteObserver(string name)
        {
            _name = name;
        }
        public void Update(string message)
        {
            Console.WriteLine($"{_name} received message: {message}");
        }
    }
}
