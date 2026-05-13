using System;
using System.Collections.Generic;
using System.Text;

namespace State.Implements
{
    public class NoMoneyState : IVendingState
    {
        private readonly VendingMachine _machine;

        public NoMoneyState(
            VendingMachine machine)
        {
            _machine = machine;
        }

        public void InsertCoin()
        {
            Console.WriteLine(
                "Coin inserted");

            _machine.State =
                new HasMoneyState(_machine);
        }

        public void PressButton()
        {
            Console.WriteLine(
                "Insert coin first");
        }
    }
}
