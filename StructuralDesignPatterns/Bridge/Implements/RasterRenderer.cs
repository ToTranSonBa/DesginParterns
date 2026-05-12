using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Implements
{
    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine(
                $"Drawing circle as pixels, radius {radius}");
        }
    }
}
