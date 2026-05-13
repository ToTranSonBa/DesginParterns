using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor.Implements
{
    public class AreaVisitor
        : IShapeVisitor
    {
        public void Visit(Circle c)
        {
            Console.WriteLine(
                Math.PI *
                c.Radius *
                c.Radius);
        }

        public void Visit(
            Rectangle r)
        {
            Console.WriteLine(
                r.Width * r.Height);
        }
    }
}
