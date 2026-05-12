using Bridge.Implements;

public class Circle : Shape
{
    private readonly float _radius;

    public Circle(
        IRenderer renderer,
        float radius)
        : base(renderer)
    {
        _radius = radius;
    }

    public override void Draw()
    {
        _renderer.RenderCircle(_radius);
    }
}