using ConsoleApp1.Implements;

class Program
{
    static void Main()
    {
        IPaymentProcessor processor =
            new PaymentAdapter(
                new LegacyPaymentGateway());

        processor.Pay(100);
    }
}