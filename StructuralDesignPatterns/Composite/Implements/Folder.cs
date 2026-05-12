using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Implements
{
    public class Folder : IFileSystemItem
    {
        private string _name;
        private List<IFileSystemItem> _items;
        public Folder(string name)
        {
            _name = name;
            _items = new List<IFileSystemItem>();
        }
        public void Add(IFileSystemItem item)
        {
            _items.Add(item);
        }
        public void Display()
        {
            Console.WriteLine($"Folder: {_name}");
            foreach (var item in _items)
            {
                item.Display();
            }
        }
    }
}
