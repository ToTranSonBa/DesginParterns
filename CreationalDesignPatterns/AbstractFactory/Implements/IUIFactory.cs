using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Implements
{
    public interface IUIFactory
    {
        public IButton CreateButton();
        public ICheckbox CreateCheckbox();
    }
}
