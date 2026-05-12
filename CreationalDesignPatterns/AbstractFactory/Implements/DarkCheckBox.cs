using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Implements
{
    public class DarkCheckBox : ICheckbox
    {
        public void Check()
        {
            Console.WriteLine("Dark CheckBox is checked.");
        }
    }
}
