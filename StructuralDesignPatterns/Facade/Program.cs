using Facade.Implements;

class Program
{
    static void Main()
    {
        var facade = new HomeTheaterFacade(new Lights(),
            new Projector(),
            new SoundSystem());

        facade.WatchMovie();

        Console.WriteLine("----");

        facade.EndMovie();
    }
}