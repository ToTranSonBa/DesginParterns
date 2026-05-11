using PrototypePattern.Implements;

class Program
{
    static void Main(string[] args)
    {
        ShapeCache.LoadCache();

        Console.WriteLine("=== Prototype Pattern Demo ===\n");

        // Lấy prototype và clone
        Shape circle1 = ShapeCache.GetShape("C1");
        Shape circle2 = ShapeCache.GetShape("C1");

        circle2.Id = "C2";
        circle2.Color = "Green";
        ((Circle)circle2).Radius = 50;
        ((Circle)circle2).Center.X = 100;
        ((Circle)circle2).Center.Y = 200;

        Shape rect1 = ShapeCache.GetShape("R1");
        Shape rect2 = ShapeCache.GetShape("R1");

        rect2.Id = "R2";
        rect2.Color = "Yellow";
        ((Rectangle)rect2).Width = 100;
        ((Rectangle)rect2).Height = 60;
        ((Rectangle)rect2).Tags.Add("Modified"); // Kiểm tra Deep Copy

        Console.WriteLine("Original prototypes (không bị thay đổi):");
        ShapeCache.GetShape("C1").Display();
        ShapeCache.GetShape("R1").Display();

        Console.WriteLine("\nCloned objects:");
        circle1.Display();
        circle2.Display();
        rect1.Display();
        rect2.Display();

        Console.ReadKey();
    }
}