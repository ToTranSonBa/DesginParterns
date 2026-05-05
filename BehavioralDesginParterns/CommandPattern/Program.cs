using CommandPattern.Implement;

public class Program
{
    public static void Main(string[] args)
    {
        var editor = new TextEditor();
        var manager = new CommandManager();

        manager.ExecuteCommand(new AppendTextCommand(editor, "Hello "));
        manager.ExecuteCommand(new AppendTextCommand(editor, "World"));

        Console.WriteLine(editor.Text); // Hello World

        manager.Undo();
        Console.WriteLine(editor.Text); // Hello 

        manager.Redo();
        Console.WriteLine(editor.Text); // Hello World
    }
}