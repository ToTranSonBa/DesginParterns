using System;
using System.Collections.Generic;
using System.Text;

namespace Facade.Implements
{
    public class SoundSystem
    {
        public void On()
        {
            Console.WriteLine("Sound system is turned on.");
        }
        public void Off()
        {
            Console.WriteLine("Sound system is turned off.");
        }
    }
}
