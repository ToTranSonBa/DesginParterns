using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Implement
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
