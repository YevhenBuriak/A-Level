namespace L4;

internal static class SpinLockSample
{
    private static SpinLock _spLock = new();

    public static void Execute()
    {
        new Thread(new ThreadStart(Lock)).Start();
        new Thread(new ThreadStart(Lock)).Start();
    }

    private static void Lock()
    {
        bool lockTaken = false;
        try
        {
            Console.WriteLine($"Attempt aquire the lock:: {Thread.CurrentThread.ManagedThreadId}");
            _spLock.Enter(ref lockTaken);
            
            Console.WriteLine($"Lock aquiried by:: {Thread.CurrentThread.ManagedThreadId}, working...");
            Thread.Sleep(5000);
        }
        finally
        {
            if (lockTaken) _spLock.Exit();
            Console.WriteLine($"process method Release the lock:: {Thread.CurrentThread.ManagedThreadId}");
        }

        //bool lockTaken2 = false;
        //_spLock.Enter(ref lockTaken2);
    }
}
