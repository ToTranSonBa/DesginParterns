using System;
using System.Collections.Generic;
using System.Text;

namespace Facade.Implements
{
    public class Lights
    {
        public void On()
        {
            Console.WriteLine("Lights are on.");
        }
        public void Off()
        {
            Console.WriteLine("Lights are off.");
        }
    }
}
