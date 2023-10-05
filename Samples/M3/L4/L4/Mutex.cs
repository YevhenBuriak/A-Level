
namespace L4;

internal static class MutexSample
{

    public static void Execute()
    {
        //MultipleProcesses();
        //SinleProcess();
    }

    public static void MultipleProcesses()
    {
        Console.WriteLine("Hello");
        Console.ReadLine();
    }

    public static void SinleProcess()
    {
        using var mutex = new Mutex(false, "MutexDemo");

        //Checking if Other External Thread is Running
        while (!mutex.WaitOne(1000, false))
        {
            Console.WriteLine("An Instance of the Application is Already Running, retrying...");
        }

        try
        {
            Console.WriteLine("Aplication started, press any key to gracefully exit.......");
            Console.ReadKey();
        }
        finally
        {
            mutex.ReleaseMutex();// what happens if not released?
        }
    }
}
