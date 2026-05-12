using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Implements
{
    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine(
                $"Drawing circle as vectors, radius {radius}");
        }
    }
}
