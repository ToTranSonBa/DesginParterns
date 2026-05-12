using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Implements
{
    public class FileItem : IFileSystemItem
    {
        private string _name;
        public FileItem(string name)
        {
            _name = name;
        }
        public void Display()
        {
            Console.WriteLine($"File: {_name}");
        }   
    }
}
