using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Implements
{
    public class LightCheckBox : ICheckbox
    {
        public void Check()
        {
            Console.WriteLine("Light CheckBox is checked.");
        }
    }
}
