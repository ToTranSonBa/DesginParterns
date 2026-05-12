using FactoryMethod.Implements;

class Program
{
    static void Main()
    {
        NotificationFactory factory = new EmailFactory();
        factory.Notify("Hello");

        factory = new SmsFactory();
        factory.Notify("Hi");
    }
}