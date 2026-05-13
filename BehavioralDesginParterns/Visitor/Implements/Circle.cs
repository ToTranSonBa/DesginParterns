using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor.Implements
{
    public class Circle : IShape
    {
        public int Radius { get; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public void Accept(
            IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
