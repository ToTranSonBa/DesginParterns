using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Implements
{
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }
}
