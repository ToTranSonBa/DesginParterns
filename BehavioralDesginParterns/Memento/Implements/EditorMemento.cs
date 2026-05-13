using System;
using System.Collections.Generic;
using System.Text;

namespace Memento.Implements
{
    public class EditorMemento
    {
        public string Text { get; }

        public EditorMemento(string text)
        {
            Text = text;
        }
    }
}
