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
        var acc = new VeryImportantBankAccount();

        //Access(acc);
        LimmitedAccess(acc);

        // ex 3
        //var deadLock = new DeadLocker();
        //deadLock.Start();

        // ex 4
        //var thread = new Thread(DoWork);
        //thread.Start((int i) => Console.WriteLine(i));

        //thread.Join();
    }

    static void DoWork(object callback)
    {
        // Do some work
        Thread.Sleep(1000);

        // Cast the callback function to a Action<int>
        var callbackFunc = (Action<int>)callback;
        callbackFunc(42);
    }

    public static void LongRunningCalc()
    {
        Thread.Sleep(2000);
        Console.WriteLine($"Done sleeping from {Thread.CurrentThread.Name}");
    }

    public static void StartWait()
    {
        Thread.CurrentThread.Name = "MAIN";
        var process = Process.GetCurrentProcess();
        _ = process.Threads.Count;

        // Start new Thread
        var thread = new Thread(LongRunningCalc);
        thread.Name = "Long running task";
        thread.Start();

        //thread.Join(); // how to wait

        Console.WriteLine($"Continue working {Thread.CurrentThread.Name}");

    }

    public static void Access(VeryImportantBankAccount acc)
    {
        var thread = new Thread(() => acc.UnsafeDeposit(30));
        var thread2 = new Thread(() => acc.UnsafeDeposit(60));
        var thread3 = new Thread(() => acc.UnsafeDeposit(90));

        thread.Start();
        thread2.Start();
        thread3.Start();

        thread.Join();
        thread2.Join();
        thread2.Join();
    }

    public static void LimmitedAccess(VeryImportantBankAccount acc)
    {
        var thread = new Thread(() => acc.Deposit(30));
        var thread2 = new Thread(() => acc.Deposit(60));
        var thread3 = new Thread(() => acc.Deposit(90));

        thread.Start();
        thread2.Start();
        thread3.Start();

        thread.Join();
        thread2.Join();
        thread2.Join();
    }

    public class VeryImportantBankAccount
    {
        private readonly object _lock = new();
        public int Balance { get; private set; }

        public void UnsafeDeposit(int balance)
        {
            Console.WriteLine($"Attempting set {balance}");
            Balance = balance;
            Thread.Sleep(1000);
            Console.WriteLine($"Active set to {Balance}");
        }

        public void Deposit(int balance)
        {
            lock (_lock)
            {
                Console.WriteLine($"Attempting set {balance}");
                Balance = balance;
                Thread.Sleep(1000);
                Console.WriteLine($"Active set to {Balance}");
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
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} acquired lock on 2");
                    Thread.Sleep(1000);

                    lock (_lock1)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} acquired lock on 1");
                    }
                }
            }
        }
    }


    // створити 2 потоки, запустити якісь довгоживучі методи
}
