using System;
using System.Collections.Generic;
using System.Text;

namespace Memento.Implements
{
    public class History
    {
        private readonly Stack<EditorMemento>
            _history = new();

        public void Push(EditorMemento m)
        {
            _history.Push(m);
        }

        public EditorMemento Pop()
        {
            return _history.Pop();
        }
    }
}
