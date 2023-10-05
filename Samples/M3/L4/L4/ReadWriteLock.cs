namespace L4;

internal static class ReadWriteLockSample
{
    private static int _counter = 0;
    static ReaderWriterLockSlim _lock = new();

    public static void Execute()
    {
        // create 5 reader threads
        for (int i = 0; i < 5; i++)
        {
            new Thread(() => Read()).Start();
        }

        // create 2 writer threads
        for (int i = 0; i < 2; i++)
        {
            new Thread(() => Write()).Start();
        }
    }

    static void Read()
    {
        while (true)
        {

            try
            {
                _lock.EnterReadLock();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"R: Thread {Thread.CurrentThread.ManagedThreadId} is reading: {_counter}");
            }
            finally
            {
                _lock.ExitReadLock();
            }

            Thread.Sleep(500);
        }
    }

    static void Write()
    {
        while (true)
        {
            try
            {
                _lock.EnterWriteLock();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"W: Thread {Thread.CurrentThread.ManagedThreadId} is writing: {_counter++}");
            }
            finally
            {
                _lock.ExitWriteLock();
            }

            Thread.Sleep(2000);
        }
    }
}


