using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Implements
{
    public class DarkButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Dark Button created.");
        }
    }
}
