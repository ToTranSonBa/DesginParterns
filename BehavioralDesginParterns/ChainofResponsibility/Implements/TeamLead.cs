using System;
using System.Collections.Generic;
using System.Text;

namespace ChainofResponsibility.Implements
{
    public class TeamLead : ApproverBase
    {
        public override void Approve(decimal amount)
        {
            if (amount <= 1000)
            {
                Console.WriteLine(
                    "TeamLead approved");
                return;
            }

            base.Approve(amount);
        }
    }
}
