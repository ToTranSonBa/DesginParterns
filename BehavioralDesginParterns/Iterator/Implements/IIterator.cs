using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Implements
{
    public interface IIterator<T>
    {
        bool HasNext();

        T Next();
    }
}
