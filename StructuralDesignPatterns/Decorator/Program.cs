using Decorator.Implements;

class Program
{
    static void Main()
    {
        ICoffee coffee =
            new SugarDecorator(
                new MilkDecorator(
                    new BaseCoffee()));

        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine(coffee.GetCost());
    }
}