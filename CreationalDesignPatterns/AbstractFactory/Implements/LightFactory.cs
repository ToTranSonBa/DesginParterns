using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Implements
{
    public class LightFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new LightButton();
        }
        public ICheckbox CreateCheckbox()
        {
            return new LightCheckBox();
        }
    }
}
