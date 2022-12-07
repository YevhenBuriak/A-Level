namespace L2;

public static partial class Partial
{
    public static void Execute()
    {
        Console.WriteLine("Hello from partial class");
        Console.WriteLine($"Property is declared somewhere else, but visible here: {SomeProperty}");
        Console.ReadLine();
        Console.Clear();
    }
}
