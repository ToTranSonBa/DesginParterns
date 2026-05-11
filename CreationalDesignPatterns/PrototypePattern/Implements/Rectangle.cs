using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern.Implements
{
    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<string> Tags { get; set; } = new List<string>(); // Reference type

        public Rectangle()
        {
            Type = "Rectangle";
            Color = "Blue";
            Width = 20;
            Height = 15;
            Tags.Add("Shape");
            Tags.Add("Rectangle");
        }

        public override void Display()
        {
            Console.WriteLine($"[Rectangle] Id={Id}, Type={Type}, Color={Color}, " +
                             $"Size={Width}x{Height}, Tags=({string.Join(", ", Tags)})");
        }

        public override IPrototype DeepClone()
        {
            Rectangle clone = (Rectangle)this.MemberwiseClone();
            clone.Tags = new List<string>(this.Tags); // Deep copy List
            return clone;
        }
    }
}
