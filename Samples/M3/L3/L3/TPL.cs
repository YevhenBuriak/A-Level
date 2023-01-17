namespace L3;

internal static class TPL
{
    public async static Task Execute()
    {
        Console.WriteLine($"Main thread id: {Environment.CurrentManagedThreadId}");

        // ex 0
        //var newTask = new Task(() => Console.WriteLine("Hello Task"));
        //var newTaskWithReturn = new Task<int>(() => 3 * 3);
        //var taskWithPredeterminedResult = Task.FromResult("Hi from completed task");
        //var taskWithCanceledResult = Task.FromCanceled(new CancellationToken(true));
        //var taskWithException = Task.FromException(new DivideByZeroException());

        //newTask.Start();

        // ex 1
        //NonBlocking();
        //Console.WriteLine($"Thread id: {Environment.CurrentManagedThreadId}, I'm still working");

        // ex 2
        //var task = Task.Run(() =>
        //{
        //    Task.Delay(3000).Wait();
        //    Console.WriteLine($"Thread id: {Environment.CurrentManagedThreadId}, I'm working!");
        //});
        //task.Wait();
        //
        //Console.WriteLine($"Thread id: {Environment.CurrentManagedThreadId}, Finally you are done!");

        // ex 3 + async
        //var task = Task.Run(async () =>
        //{
        //    await Task.Delay(3000);
        //    Console.WriteLine($"Thread id: {Environment.CurrentManagedThreadId}, I'm working!");
        //});
        //await task;
        //
        //Console.WriteLine($"Thread id: {Environment.CurrentManagedThreadId}, Finally you are done!");


        //ex 4
        //var cts = new CancellationTokenSource();
        //var task = new CustomTask(cts.Token);
        //var customTask = task.Run();
        //
        //var customCancelTask = Task.Run(() =>
        //{
        //    Console.WriteLine("Press enter to cancel the task");
        //    Console.ReadLine();
        //
        //    // Cancel the task
        //    cts.Cancel();
        //});
        ////await Task.WhenAll(customTask, customCancelTask);
        //Task.WaitAll(customTask, customCancelTask);

        // ex 5
        //var task = Task.Run(() =>
        //    {
        //        Console.WriteLine("Write a number");
        //        var input = Console.ReadLine();
        //        var i = int.Parse(input!);

        //        return i;
        //    })
        //    .ContinueWith(async (i) =>
        //    {
        //        await Task.Delay(1000);
        //        Console.WriteLine($"I thing this is enough {i.Result}");
        //    });

        //await task;

        // ex 5
        //var taskWithError = Task.Run(() =>
        //{
        //    var zero = 0;
        //    return 10 / zero;
        //});
        //var taskWithError2 = Task.Run(() =>
        //{
        //    throw new NullReferenceException();
        //});


        //try
        //{
        //    //await taskWithError;
        //    //task.Wait();
        //    //await Task.WhenAll(taskWithError, taskWithError2);
        //    //Task.WaitAll(taskWithError, taskWithError2);
        //}
        //catch (AggregateException ex)
        //{
        //    Console.WriteLine($"Failed to execute {ex}");
        //}
        //catch (DivideByZeroException ex)
        //{
        //    Console.WriteLine($"Failed to execute {ex}");
        //}
        //catch (NullReferenceException ex)
        //{
        //    Console.WriteLine($"Failed to execute {ex}");
        //}

        // ex 6
        var tasks = new List<Task<int>>()
        {
            Task.Run(async () => { await Task.Delay(100); return 1; }),
            Task.Run(async () => { await Task.Delay(500); return 2; }),
            Task.Run(async () => { await Task.Delay(600); return 3; }),
        };

        var whenAll = await Task.WhenAll(tasks);
        var whenAny = await Task.WhenAny(tasks);
    }

    public static void NonBlocking()
    {
        Task.Run(() =>
        {
            Task.Delay(3000);
            Console.WriteLine($"Thread id: {Environment.CurrentManagedThreadId}, I'm done");
        });
    }

    class CustomTask
    {
        private readonly CancellationToken _token;

        public CustomTask(CancellationToken token)
        {
            _token = token;
        }

        public async Task Run()
        {
            Console.WriteLine("Custom task started");

            for (int i = 0; i < 10; i++)
            {
                _token.ThrowIfCancellationRequested();

                // Do some work
                Console.WriteLine("Custom task running: " + i);
                await Task.Delay(1000);
            }

            Console.WriteLine("Custom task completed");
        }
    }
}
