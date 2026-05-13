using System;
using System.Collections.Generic;
using System.Text;

namespace Memento.Implements
{
    public class Editor
    {
        public string Text { get; set; } = "";

        public EditorMemento Save()
        {
            return new EditorMemento(Text);
        }

        public void Restore(
            EditorMemento memento)
        {
            Text = memento.Text;
        }
    }
}
