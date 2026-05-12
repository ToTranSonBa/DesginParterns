using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Implements
{
    public class DarkFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new DarkButton();
        }
        public ICheckbox CreateCheckbox()
        {
            return new DarkCheckBox();
        }
    }
}
