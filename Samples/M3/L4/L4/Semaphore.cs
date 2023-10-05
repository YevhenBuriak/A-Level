using System.Threading;

namespace L4;

internal static class SemaphoreSample
{
    private static Semaphore? _semaphore = null;
    public static void Execute()
    {
        try
        {
            //Try to Open the Semaphore if Exists, if not throw an exception
            _semaphore = Semaphore.OpenExisting("SemaphoreDemo");
        }
        catch 
        {
            //Here Maximum 2 external threads can access the code at the same time
            _semaphore = new Semaphore(2, 2, "SemaphoreDemo");
        }


        Console.WriteLine("External Thread Trying to Acquiring");
        _semaphore.WaitOne();
        Console.WriteLine("External Thread Acquired");
        Console.ReadKey();
        _semaphore.Release();
    }
}
