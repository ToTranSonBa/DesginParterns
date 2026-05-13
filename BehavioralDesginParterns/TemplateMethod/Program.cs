using TemplateMethod.Implements;

class Program
{
    static void Main()
    {
        Beverage tea = new Tea();
        tea.Prepare();

        Console.WriteLine("----");

        Beverage coffee = new Coffee();
        coffee.Prepare();
    }
}