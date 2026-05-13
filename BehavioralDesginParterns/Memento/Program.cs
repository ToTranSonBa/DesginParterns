using Memento.Implements;

class Program
{
    static void Main()
    {
        var editor = new Editor();

        var history = new History();

        editor.Text = "Hello";
        history.Push(editor.Save());

        editor.Text = "Hello World";
        history.Push(editor.Save());

        editor.Text = "Hello World!!!";

        Console.WriteLine(editor.Text);

        editor.Restore(history.Pop());

        Console.WriteLine(editor.Text);

        editor.Restore(history.Pop());

        Console.WriteLine(editor.Text);
    }
}