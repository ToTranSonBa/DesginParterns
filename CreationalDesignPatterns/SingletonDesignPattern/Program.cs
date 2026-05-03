using SingletonDesignPattern;

public class Program
{
    public static void Main(string[] args)
    {
        Thread thread1 = new(() => LogSingleton.GetInstance().Log());
        Thread thread2 = new(() => LogSingleton.GetInstance().Log());

        thread1.Start();
        thread2.Start();
    }
}