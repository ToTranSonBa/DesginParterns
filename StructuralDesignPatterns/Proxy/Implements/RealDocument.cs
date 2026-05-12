using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.Implements
{
    public class RealDocument : IDocument
    {
        private string _fileName;
        public RealDocument(string fileName)
        {
            _fileName = fileName;
            LoadFromDisk();
        }
        private void LoadFromDisk()
        {
            Console.WriteLine($"Loading document {_fileName} from disk...");
        }
        public void Display()
        {
            Console.WriteLine($"Displaying document {_fileName}");
        }
    }
}
