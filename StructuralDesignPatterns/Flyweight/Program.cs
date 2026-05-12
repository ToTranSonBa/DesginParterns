using Flyweight.Implements;

class Program
{
    static void Main()
    {
        var factory =
            new CharacterFactory();

        string text = "HELLO";

        for (int i = 0; i < text.Length; i++)
        {
            var ch = factory.GetCharacter(text[i]);

            ch.Display(i, 0);
        }
    }
}