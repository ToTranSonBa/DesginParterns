using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Implements
{
    public abstract class Shape
    {
        protected readonly IRenderer _renderer;

        protected Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract void Draw();
    }
}
