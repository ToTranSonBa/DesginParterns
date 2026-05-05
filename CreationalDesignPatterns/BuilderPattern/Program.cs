using BuilderPattern.Implements;

class Program
{
    static void Main(string[] args)
    {
        var gamingPC = new ComputerBuilder()
            .SetCPU("Intel i9")
            .SetRAM("32GB")
            .SetStorage("1TB SSD")
            .SetGPU("RTX 4090")
            .EnableWifi()
            .Build();

        Console.WriteLine("Gaming PC:");
        Console.WriteLine(gamingPC);

        var officePC = new ComputerBuilder()
            .SetCPU("Intel i5")
            .SetRAM("16GB")
            .SetStorage("512GB SSD")
            .Build();

        Console.WriteLine("\nOffice PC:");
        Console.WriteLine(officePC);
    }
}