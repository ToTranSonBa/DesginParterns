using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor.Implements
{
    public class DrawVisitor
        : IShapeVisitor
    {
        public void Visit(Circle c)
        {
            Console.WriteLine(
                $"Draw circle {c.Radius}");
        }

        public void Visit(
            Rectangle r)
        {
            Console.WriteLine(
                $"Draw rect {r.Width}x{r.Height}");
        }
    }
}
