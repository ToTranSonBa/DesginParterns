using ObserverPattern.Implements;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a subject
        ISubject subject = new ConcreteSubject();
        // Create observers
        IObserver observer1 = new ConcreteObserver("Observer 1");
        IObserver observer2 = new ConcreteObserver("Observer 2");
        // Attach observers to the subject
        subject.Attach(observer1);
        subject.Attach(observer2);
        // Notify observers with a message
        subject.Notify("Hello, Observers!");
        // Detach one observer and notify again
        subject.Detach(observer1);
        subject.Notify("Hello again, Observers!");
    }
}