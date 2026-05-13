using Iterator.Implements;

class Program
{
    static void Main()
    {
        var names =
            new NameCollection();

        names.Add("Alice");
        names.Add("Bob");
        names.Add("Charlie");

        var iterator =
            names.CreateIterator();

        while (iterator.HasNext())
        {
            Console.WriteLine(
                iterator.Next());
        }
    }
}