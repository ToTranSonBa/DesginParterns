using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern.Implements
{
    public static class ShapeCache
    {
        private static readonly Dictionary<string, Shape> _cache = [];

        public static void LoadCache()
        {
            // Circle prototype
            Circle circle = new()
            {
                Id = "C1"
            };
            _cache.Add(circle.Id, circle);

            // Rectangle prototype
            Rectangle rect = new()
            {
                Id = "R1"
            };
            _cache.Add(rect.Id, rect);
        }

        public static Shape? GetShape(string id)
        {
            if (_cache.TryGetValue(id, out Shape shape))
            {
                return (Shape)shape.DeepClone(); // Luôn dùng DeepClone để an toàn
            }
            return null;
        }

        public static void AddPrototype(string id, Shape shape)
        {
            _cache[id] = shape;
        }
    }
}
