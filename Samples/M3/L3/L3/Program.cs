namespace L3;

internal class Program
{
    static async Task Main(string[] args)
    {
        // ProcessSmaples.Execute();
        // Threads.Execute();
        await TPL.Execute();
    }
}