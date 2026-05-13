using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Implements
{
    public class NameCollection
        : IAggregate<string>
    {
        private readonly List<string> _items
            = new();

        public void Add(string name)
        {
            _items.Add(name);
        }

        public string Get(int index)
        {
            return _items[index];
        }

        public int Count => _items.Count;

        public IIterator<string>
            CreateIterator()
        {
            return new NameIterator(this);
        }
    }
}
