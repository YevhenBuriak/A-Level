namespace L3;

//Abstract class: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
//Interfaces: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces
internal class Abstructions
{
    public static void Execute()
    {
        var triathlon = new Triathlon();
        Swimmable swimmable = triathlon;
        IRunnanble runnable = triathlon;
        ICyclable cyclable = triathlon;

        swimmable.Swim();
        runnable.Run();
        cyclable.Cycle();
    }

    private interface IRunnanble
    {
        public bool IsFinished { get; init; }

        void Run();
        string Run(int km);

        //string Run(float km) => $"We ran {km}";
    }

    private interface ICyclable
    {
        public bool IsFinished { get; init; }

        void Cycle();
        string Cycle(int km);

        //string Run(float km) => $"We ran {km}";
    }

    public abstract class Swimmable
    {
        public float WhaterTemperature { get; init; } = 35.5f;
        public abstract bool IsFinished { get; set; }

        public abstract void Swim();
        public virtual string Swim(int km) => $"We swam {km}";
    }

    public class Triathlon : Swimmable, IRunnanble, ICyclable
    {
        public override bool IsFinished
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        bool ICyclable.IsFinished
        {
            get => throw new NotImplementedException();
            init => throw new NotImplementedException();
        }

        //Notice - no modifier
        bool IRunnanble.IsFinished
        {
            get => throw new NotImplementedException();
            init => throw new NotImplementedException();
        }

        public void Cycle()
        {
            throw new NotImplementedException();
        }

        public string Cycle(int km)
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public string Run(int km)
        {
            throw new NotImplementedException();
        }

        public override void Swim()
        {
            throw new NotImplementedException();
        }
    }
}
