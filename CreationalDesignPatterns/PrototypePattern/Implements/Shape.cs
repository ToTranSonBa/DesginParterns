using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern.Implements
{
    public abstract class Shape : IPrototype
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }

        public virtual IPrototype Clone()
        {
            return (IPrototype)this.MemberwiseClone();
        }

        public abstract IPrototype DeepClone();

        public abstract void Display();
    }
}
