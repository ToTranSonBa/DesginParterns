using AbstractFactory.Implements;

class Program
{
    static void Main()
    {
        IUIFactory factory = new DarkFactory();

        var button = factory.CreateButton();
        var checkbox = factory.CreateCheckbox();

        button.Render();
        checkbox.Check();
    }
}