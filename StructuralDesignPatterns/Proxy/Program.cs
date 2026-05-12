using Proxy.Implements;

class Program
{
    static void Main()
    {
        IDocument doc =
            new DocumentProxy("report.pdf");

        Console.WriteLine("Proxy created");

        doc.Display();
        doc.Display();
    }
}