using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.Implements
{
    public class DocumentProxy : IDocument
    {
        private string _fileName;
        private RealDocument _realDocument;
        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
        }
        public void Display()
        {
            if (_realDocument == null)
            {
                _realDocument = new RealDocument(_fileName);
            }
            _realDocument.Display();
        }
    }
}
