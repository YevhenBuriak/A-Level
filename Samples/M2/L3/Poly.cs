namespace L3;

//Polymorphism: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/polymorphism

public static class Poly
{
    public static void Execute()
    {
        Child child = new Child();
        GrownUp grownUp = new GrownUp();
        Human human = new Human();

        human.SleepDefaultBehavior();
        human.SleepVirtualBehavior();

        Console.ReadLine();
        Console.Clear();

        //1. Default behavior
        human = child;
        human.SleepDefaultBehavior(); // new
        human = grownUp;
        human.SleepDefaultBehavior(); // new

        Console.ReadLine();
        Console.Clear();

        //2. Virtual-Override-New
        human = child;
        human.SleepVirtualBehavior(); // new
        human = grownUp;
        human.SleepVirtualBehavior(); // override

        Console.ReadLine();
        Console.Clear();
    }

    private class Human
    {
        public int SleepHours { get; init; } = 8;
        public void SleepDefaultBehavior() => Console.WriteLine($"Human sleeps for {SleepHours}");
        public virtual void SleepVirtualBehavior() => Console.WriteLine($"Human sleeps for {SleepHours}");
        public virtual void SleepSealed() => Console.WriteLine($"Human sleeps for {SleepHours}");
    }

    private class Child : Human
    {
        //Has compiler warning
        public void SleepDefaultBehavior() => Console.WriteLine($"Child sleeps for {SleepHours}");
        public new void SleepVirtualBehavior() => Console.WriteLine($"Child sleeps for {SleepHours}");
        public sealed override void SleepSealed() => Console.WriteLine($"Human sleeps for {SleepHours}");
    }

    private class GrownUp : Human
    {
        public new void SleepDefaultBehavior() => Console.WriteLine($"GrownUp sleeps for {SleepHours}");
        public override void SleepVirtualBehavior() => Console.WriteLine($"GrownUp sleeps for {SleepHours}");
    }

    private class SuperChild : Child
    {
        //public override void SleepSealed() => Console.WriteLine($"Human sleeps for {SleepHours}");
    }
}
