//Comments: https://www.geeksforgeeks.org/comments-in-c-sharp/
//Namespaces: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/namespace

namespace L1;

//Access modifiers: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

//Classes: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes
public class SimplePersonClass
{
    //Fields: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields
    public int amountOfFrieands = 10;
    protected string? _birthName;

    private int _age = 0;
    private string? _name;
    private string? _fullName;


    //Properties: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties

    public static int Hi { get; set; } //Set/Init - Update; Get- Read
    public int AmountOfMonye { get; set; }
    private string PetName { get; set; } = "Buddy";
    protected int YearOfBirth => DateTime.Now.AddDays(-_age).Year;

    public string FullName
    {
        get { return $"{_name ?? "Mr"} {_birthName}"; }
        private set { _fullName = value; }
    }

    //Constructors: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
    public SimplePersonClass(int age, string name) : this(age)
    {
        _name = name;
    }

    protected SimplePersonClass(int age) => _age = age;

    //Methods: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods

    public void SayHi()
    {
        Console.WriteLine($"Hi: {FullName}");
    }

    public string GetPersonalData() =>
        $"Name: {FullName}, Age: {_age}, Year of birth: {YearOfBirth}, Pet name: {PetName}, Money: {AmountOfMonye}";
}
