using System;
using System.Collections.Generic;
using System.Text;

namespace ChainofResponsibility.Implements
{
    public abstract class ApproverBase
        : IApprover
    {
        private IApprover? _next;

        public IApprover SetNext(IApprover next)
        {
            _next = next;
            return next;
        }

        public virtual void Approve(decimal amount)
        {
            _next?.Approve(amount);
        }
    }
}
