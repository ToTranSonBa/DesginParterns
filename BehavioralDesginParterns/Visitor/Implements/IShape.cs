using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor.Implements
{
    public interface IShape
    {
        void Accept(
            IShapeVisitor visitor);
    }
}
