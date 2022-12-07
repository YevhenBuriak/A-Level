namespace L1;

internal class Program
{
    static void Main()
    {
        //Uncomment to execute:
        //WorkWithClasses();
        //WorkWithStructs();
        //WorkWithStatic();
        //WorkWithDttm();
        Console.WriteLine(TimeZoneInfo.Local);

        var anonymousType = new { Value = 10, ShoZavgodno = new SimplePersonClass(21, "John") };
    }

    private static void WorkWithClasses()
    {
        Console.WriteLine("Creating instance of .net classes\n");

        string repeatTwoTimes = new string('2', 3);

        Console.WriteLine(repeatTwoTimes);

        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Creating instance of custom classes\n");

        SimplePersonClass me = new SimplePersonClass(21, "John");
        SimplePersonClass mySister = new(17, "Sansa");
        var myFriend = new SimplePersonClass(120, "Capitan Morgan");

        Console.WriteLine(me.FullName);
        Console.WriteLine(myFriend.FullName);
        Console.WriteLine(mySister.FullName);

        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Accessing public members\n");

        me.amountOfFrieands = 15;
        me.AmountOfMonye = 10 * 10;
        me.SayHi();
        var data = me.GetPersonalData();
        Console.WriteLine(data);

        Console.ReadLine();
        Console.Clear();
    }

    private static void WorkWithStructs()
    {
        Console.WriteLine("Creating instance of .net structs\n");

        int digit = new Int32();
        Console.WriteLine(digit);

        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Creating instance of custom structs\n");

        var defaultCoords = new SimpleCoordinatesStruct(2.3m);
        var coords = new SimpleCoordinatesStruct(1.2m, 2.33m);

        Console.WriteLine(defaultCoords.X);
        Console.WriteLine(defaultCoords.Y);

        var sum = coords + defaultCoords;

        Console.WriteLine(sum.X);
        Console.WriteLine(sum.Y);


        Console.ReadLine();
        Console.Clear();
    }

    private static void WorkWithStatic()
    {
        Console.WriteLine("Calling static + overload methods\n");

        Console.WriteLine(StaticAdder.Add(1, 2));
        Console.WriteLine(StaticAdder.Add(1, 2, 3, 4, 5));
        Console.WriteLine(StaticAdder.Add("Hello", "World"));

        Console.ReadLine();
        Console.Clear();
    }

    private static void WorkWithDttm()
    {
        Console.WriteLine("Date Time\n");

        var calculator = new BirthdayCalculator("Mr President", DateTime.Today.AddYears(-55), "US");
        calculator.Sing();


        Console.ReadLine();
        Console.Clear();

        calculator = new BirthdayCalculator("Mr President", new DateTime(1990, 12, 10), "US");
        calculator.Sing();

        Console.ReadLine();
        Console.Clear();
    }
}