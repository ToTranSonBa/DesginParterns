using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Implement
{
    public class TextEditor
    {
        private StringBuilder _content;
        public string Text => _content.ToString();
        public TextEditor()
        {
            _content = new StringBuilder();
        }
        public void Append(string text)
        {
            _content.Append(text);
        }
        public void Remove(int length)
        {
            if (length > _content.Length)
                length = _content.Length;
            _content.Remove(_content.Length - length, length);
        }
        public string GetContent()
        {
            return _content.ToString();
        }
    }
}
