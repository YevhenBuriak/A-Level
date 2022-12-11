namespace L3;

//Inheritance: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance

public static class Inheritance
{
    public static void Execute()
    {
        Human human = new Human(8);
        human = new Child(14);
        human = new GrownUp(8);

        human.Breath();
        human.Sleep();
        //human.Run();

        Console.ReadLine();
        Console.Clear();

        Child child = new Child(14);
        child.Breath();
        child.Sleep();
        child.Run();

        Console.ReadLine();
        Console.Clear();

        object obj = child;
        object obj2 = human;

        Console.WriteLine(obj.ToString());
        Console.WriteLine(human.ToString());
        Console.WriteLine(child.ToString());

        Console.ReadLine();
        Console.Clear();

        Console.WriteLine($"Type: {obj.GetType()}");
        Console.WriteLine($"Type: {human.GetType()}");
        Console.WriteLine($"Type: {child.GetType()}");

        Console.ReadLine();
        Console.Clear();

        Console.WriteLine($"Is obj a human? {obj is Human}");
        Console.WriteLine($"Is obj a child? {obj is Child}");
        Console.WriteLine($"Is obj an array? {obj is Array}");

        Console.WriteLine($"Obj (safe casted) as a child: {obj as Child}");
        Console.WriteLine($"Obj (safe casted) as an array: {obj as Array}");

        Console.WriteLine($"Obj as an array with fall-back: {obj as Array ?? Array.Empty<object>()}");

        Console.WriteLine($"Obj casted as a child: {(Child)obj}");
        //Console.WriteLine($"Obj casted as an array: {(Array)obj}");

        var upcast = (Human)child;
        upcast = child as Human;

        var downcast = human as GrownUp;
        downcast = (GrownUp)human;

        var failedDowncast = human as Child;
        //failedDowncast = (Child)human;

        Console.ReadLine();
        Console.Clear();
    }

    private class Human
    {
        public int SleepHours { get; init; } = 8;

        public Human(int sleepHours) => SleepHours = sleepHours;

        public void Breath() => Console.WriteLine("Breathing");
        public void Sleep() => Console.WriteLine($"Sleeping for {SleepHours}");
        public void Awake() => Console.WriteLine("Awakening");
        public void Cry() => Console.WriteLine("Crying");

    }

    private class Child : Human
    {
        public int RunsPerDay { get; init; } = 10;
        public int BumpsPerDay { get; init; } = 10;

        public Child(int sleepHours) : base(sleepHours) { }

        public void Run() => Console.WriteLine($"Running my {RunsPerDay}'s run");
    }

    private class GrownUp : Human
    {
        public int ActuallySlept => base.SleepHours - 2;

        public GrownUp(int sleepHours) : base(sleepHours) { }
    }
}
