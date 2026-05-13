using System;
using System.Collections.Generic;
using System.Text;

namespace ChainofResponsibility.Implements
{
    public class Manager : ApproverBase
    {
        public override void Approve(decimal amount)
        {
            if (amount <= 5000)
            {
                Console.WriteLine(
                    "Manager approved");
                return;
            }

            base.Approve(amount);
        }
    }
}
