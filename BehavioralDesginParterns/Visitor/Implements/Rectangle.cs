using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor.Implements
{
    public class Rectangle : IShape
    {
        public int Width { get; }
        public int Height { get; }

        public Rectangle(
            int width,
            int height)
        {
            Width = width;
            Height = height;
        }

        public void Accept(
            IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
