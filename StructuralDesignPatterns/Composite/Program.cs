using Composite.Implements;

class Program
{
    static void Main()
    {
        var root = new Folder("Root");

        root.Add(new FileItem("file1.txt"));
        root.Add(new FileItem("file2.txt"));

        var subFolder = new Folder("Sub");

        subFolder.Add(
            new FileItem("subfile.txt"));

        root.Add(subFolder);

        root.Display();
    }
}