
namespace PrototypePattern.Implements
{
    public class Circle : Shape
    {
        public int Radius { get; set; }
        public Point Center { get; set; } = new Point();

        public Circle()
        {
            Type = "Circle";
            Color = "Red";
            Radius = 10;
            Center.X = 0;
            Center.Y = 0;
        }

        public override IPrototype DeepClone()
        {
            Circle clone = (Circle)this.MemberwiseClone(); // Shallow trước
            clone.Center = new Point { X = this.Center.X, Y = this.Center.Y }; // Deep cho reference type
            return clone;
        }

        public override void Display()
        {
            Console.WriteLine($"[Circle] Id={Id}, Type={Type}, Color={Color}, " +
                                     $"Radius={Radius}, Center=({Center.X}, {Center.Y})");
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
