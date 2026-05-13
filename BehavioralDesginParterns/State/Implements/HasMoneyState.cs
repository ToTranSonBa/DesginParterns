using System;
using System.Collections.Generic;
using System.Text;

namespace State.Implements
{
    public class HasMoneyState : IVendingState
    {
        private readonly VendingMachine _machine;

        public HasMoneyState(
            VendingMachine machine)
        {
            _machine = machine;
        }

        public void InsertCoin()
        {
            Console.WriteLine(
                "Already has coin");
        }

        public void PressButton()
        {
            Console.WriteLine(
                "Dispensing...");

            _machine.State =
                new NoMoneyState(_machine);
        }
    }
}
