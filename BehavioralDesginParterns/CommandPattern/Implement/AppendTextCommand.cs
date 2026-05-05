using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Implement
{
    public class AppendTextCommand(TextEditor textEditor, string text) : ICommand
    {
        private readonly TextEditor _textEditor = textEditor;
        private readonly string _text = text;

        public void Execute()
        {
            _textEditor.Append(_text);
        }

        public void Undo()
        {
            _textEditor.Remove(_text.Length);
        }
    }
}
