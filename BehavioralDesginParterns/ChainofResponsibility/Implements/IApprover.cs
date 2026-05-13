using System;
using System.Collections.Generic;
using System.Text;

namespace ChainofResponsibility.Implements
{
    public interface IApprover
    {
        IApprover SetNext(IApprover next);

        void Approve(decimal amount);
    }
}
