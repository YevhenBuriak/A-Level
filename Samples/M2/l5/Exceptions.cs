using System.Collections;

namespace L5;

// Exceptions: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/

internal static class Exceptions
{
    public static void Execute()
    {
        // 1:
        Person person = null;
        _ = person.Age;

        // 2:
        int a = 0;
        int b = 10;
        var c = b / a;

        // 3:
        var array = new int[2] { 1, 2 };
        _ = array[3];

        // 3:
        person = new Person();
        person.Age = -1;
        person.Age = 121;

        // 4:
        try
        {
            person.CashOnHands = 10;
            person.Age = -2;
        }
        catch (AgeOutsideOfBoundsException ex) when (person.CashOnHands == 10)
        {
            Console.WriteLine("From catch and more than 10:");
            Console.WriteLine(ex.Message);
        }
        catch (AgeOutsideOfBoundsException ex)
        {
            Console.WriteLine("From catch");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            //throw;
            //throw ex;
        }
        finally
        {
            Console.WriteLine("From finally:");
            Console.WriteLine(person.ToString());
        }
    }

    public class Person
    {
        private int _age;

        public int CashOnHands { get; set; }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 120) throw new AgeOutsideOfBoundsException();

                _age = value;
            }
        }
    }

    public class AgeOutsideOfBoundsException : Exception
    {
        public int LowerBound => 0;
        public int UpperBound => 120;
        public override string Message => "Age outside of bounds";
        public override IDictionary Data => new Dictionary<string, int>
        {
            { nameof(LowerBound), LowerBound },
            { nameof(UpperBound), UpperBound }
        };
    }

}
