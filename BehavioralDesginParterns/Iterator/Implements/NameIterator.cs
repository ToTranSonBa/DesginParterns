using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Implements
{
    public class NameIterator
        : IIterator<string>
    {
        private readonly NameCollection
            _collection;

        private int _index = 0;

        public NameIterator(
            NameCollection collection)
        {
            _collection = collection;
        }

        public bool HasNext()
        {
            return _index <
                _collection.Count;
        }

        public string Next()
        {
            return _collection.Get(_index++);
        }
    }
}
