using Bridge.Implements;

class Program
{
    static void Main()
    {
        Shape vectorCircle =
            new Circle(
                new VectorRenderer(),
                5);

        Shape rasterCircle =
            new Circle(
                new RasterRenderer(),
                10);

        vectorCircle.Draw();
        rasterCircle.Draw();
    }
}