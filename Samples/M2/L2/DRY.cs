namespace L2;

public class DRY
{
    public static void PrintToConsole(params string[] messages)
    {
        foreach (var message in messages)
        {
            Console.WriteLine(message);
        }

        Console.Read();
        Console.Clear();
    }
}
