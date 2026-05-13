using System;
using System.Collections.Generic;
using System.Text;

namespace State.Implements
{
    public class VendingMachine
    {
        public IVendingState State { get; set; }

        public VendingMachine()
        {
            State = new NoMoneyState(this);
        }

        public void InsertCoin()
        {
            State.InsertCoin();
        }

        public void PressButton()
        {
            State.PressButton();
        }
    }
}
