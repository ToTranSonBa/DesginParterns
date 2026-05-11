using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern.Implements
{
    public interface IPrototype
    {
        IPrototype Clone();           // Shallow hoặc Deep copy
        IPrototype DeepClone();       // Deep copy rõ ràng
        void Display();
    }
}
