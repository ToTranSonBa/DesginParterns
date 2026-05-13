using System;
using System.Collections.Generic;
using System.Text;

namespace ChainofResponsibility.Implements
{
    public class Director : ApproverBase
    {
        public override void Approve(decimal amount)
        {
            Console.WriteLine(
                "Director approved");
        }
    }
}
