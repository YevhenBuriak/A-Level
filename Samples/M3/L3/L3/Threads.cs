using System.Diagnostics;

namespace L3;

// https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-7.0

internal static class Threads
{
    public static void Execute()
    {
        // ex 1
        //StartWait();

        // ex 2
        for (var i = 0; i < 10; i++)
        {
            //Access();
            //LimmitedAccess();
        }

        // ex 3
        //var deadLock = new DeadLocker();
        //deadLock.Start();

        // ex 4
        //var thread = new Thread(DoWork);
        //thread.Start((int i) => Console.WriteLine(i));
        //
        //thread.Join();
    }

    static void WithCallBack(object callback)
    {
        // Do some work
        Thread.Sleep(1000);

        // Cast the callback function to a Action<int>
        var callbackFunc = (Action<int>)callback;
        callbackFunc(42);
    }

    public static void LongRunningCalc()
    {
        Thread.Sleep(3000);
        Console.WriteLine("Done sleeping");
    }

    public static void StartWait()
    {
        var process = Process.GetCurrentProcess();
        _ = process.Threads.Count;

        // Start new Thread
        var thread = new Thread(LongRunningCalc);
        thread.Name = "Long running task";
        thread.Start();

        Console.WriteLine("Continue working");

        thread.Join(); // waiting
    }

    public static void Access()
    {
        var limmitedAccess = new Locked();

        var thread = new Thread(() => limmitedAccess.IncrementUnSafellyNtimes(1000));
        var thread2 = new Thread(() => limmitedAccess.IncrementUnSafellyNtimes(1000));
        var thread3 = new Thread(() => limmitedAccess.IncrementUnSafellyNtimes(1000));

        thread.Start();
        thread2.Start();
        thread3.Start();

        thread.Join();
        thread2.Join();
        thread2.Join();

        Console.WriteLine(limmitedAccess.SomeIntValue);
    }

    public static void LimmitedAccess()
    {
        var limmitedAccess = new Locked();

        var thread = new Thread(() => limmitedAccess.IncrementSafellyNtimes(1000));
        var thread2 = new Thread(() => limmitedAccess.IncrementSafellyNtimes(1000));
        var thread3 = new Thread(() => limmitedAccess.IncrementSafellyNtimes(1000));

        thread.Start();
        thread2.Start();
        thread3.Start();

        thread.Join();
        thread2.Join();
        thread2.Join();

        Console.WriteLine(limmitedAccess.SomeIntValue);
    }

    public class Locked
    {
        private readonly object _lock = new();
        public int SomeIntValue { get; private set; }

        public Locked(int initial = 0) => SomeIntValue = initial;
        public void IncrementUnSafellyNtimes(int n)
        {
            for (var i = 0; i < n; i++)
            {
                SomeIntValue++;
            }
        }

        public void IncrementSafellyNtimes(int n)
        {
            for (var i = 0; i < n; i++)
            {
                lock (_lock)
                {
                    SomeIntValue++;
                }
            }
        }
    }

    public class DeadLocker
    {
        private readonly object _lock1 = new();
        private readonly object _lock2 = new();
        public void Start()
        {
            var thread1 = new Thread(AcquireLocks);
            thread1.Start();

            var thread2 = new Thread(AcquireReveredLocks);
            thread2.Start();

            // Wait for the threads to finish
            thread1.Join();
            thread2.Join();
        }

        private void AcquireLocks()
        {
            lock (_lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} acquired lock on 1");
                Thread.Sleep(1000);

                lock (_lock2)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} acquired lock on 2");
                }
            }
        }

        private void AcquireReveredLocks()
        {
            lock (_lock2)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} acquired lock on 1");
                Thread.Sleep(1000);

                lock (_lock1)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} acquired lock on 2");
                }
            }
        }
    }
}
