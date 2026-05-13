using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Visitor.Implements
{
    public interface IShapeVisitor
    {
        void Visit(Circle circle);

        void Visit(Rectangle rectangle);
    }
}
