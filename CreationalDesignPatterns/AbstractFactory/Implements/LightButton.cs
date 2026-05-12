 using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Implements
{
    public class LightButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Light Button created.");
        }
    }
}
