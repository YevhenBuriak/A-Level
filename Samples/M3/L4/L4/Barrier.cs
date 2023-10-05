namespace L4;

internal static class BarrierSample
{
    private static readonly Barrier _barrier = new(participantCount: 5);

    public static void Execute()
    {
        Task[] tasks = new Task[5];

        for (int i = 0; i < 5; ++i)
        {
            int j = i;
            tasks[j] = Task.Run(() =>
            {
                GetDataAndStoreData(j);
            });
        }

        Task.WaitAll(tasks);

        Console.WriteLine("Backup completed");
        Console.ReadLine();
    }

    private static void GetDataAndStoreData(int index)
    {
        Console.WriteLine("Getting data from server: " + index);
        var rnd = new Random();
        Thread.Sleep(TimeSpan.FromSeconds(rnd.Next(1, 5)));
        Console.WriteLine("Getting data from server - done " + index);

        _barrier.SignalAndWait();

        Console.WriteLine("Send data to Backup server: " + index);

        _barrier.SignalAndWait();
    }        
}
