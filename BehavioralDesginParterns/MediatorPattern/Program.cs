using MediatorPattern.Implements;

public class Program
{
    public static void Main(string[] args)
    {
        var mediator = new ChatMediator();
        var user1 = new User(mediator, "Alice");
        var user2 = new User(mediator, "Bob");
        var user3 = new User(mediator, "Charlie");
        mediator.Register(user1);
        mediator.Register(user2);
        mediator.Register(user3);
        user1.Send("Hello, everyone!");
        user2.Send("Hi Alice!");
        user3.Send("Hey Alice and Bob!");
    }
}