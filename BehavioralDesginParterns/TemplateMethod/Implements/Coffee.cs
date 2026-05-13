using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod.Implements
{
    public class Coffee : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Brewing coffee");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding sugar and milk");
        }
    }
}
