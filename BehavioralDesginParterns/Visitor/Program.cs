using Visitor.Implements;

class Program
{
    static void Main()
    {
        var shapes = new IShape[]
        {
            new Circle(5),
            new Rectangle(4,6)
        };

        var draw =
            new DrawVisitor();

        var area =
            new AreaVisitor();

        foreach (var shape in shapes)
        {
            shape.Accept(draw);

            shape.Accept(area);

        }
    }
}