namespace L2;

public class NewTouples
{
    public int Age { get; set; }
    public string? Name { get; set; }

    public Tuple<int, int>? OldTouple { get; set; } = null;

    public NewTouples(int age, string name) => (Age, Name) = (age, name);

    public void Deconstruct(out int age, out string? name)
    {
        age = Age;
        name = Name;
    }

    public (int Age, string? Name) TouplesAsReturn()
    {
        return (Age, Name);
    }

    public (int, string?) TouplesWithoutNameAsReturn()
    {
        return (Age, Name);
    }

    public void TouplesAsParams((int Age, string? Name) param)
    {
        var age = param.Age;
        var name = param.Name;
    }

    public void TouplesWithoutNameAsParams((int, string?) param)
    {
        var age = param.Item1;
        var name = param.Item2;
    }

    public static void Execute()
    {
        Console.WriteLine("Touples:");

        var created = new NewTouples(20, "John"); // create
        var (age, name) = created; // deconstruct

        var toupleWithName = created.TouplesAsReturn();
        _ = toupleWithName.Age;

        var toupleWithoutName = created.TouplesWithoutNameAsReturn();
        _ = toupleWithoutName.Item1;

        created.TouplesWithoutNameAsParams(toupleWithoutName);
        created.TouplesWithoutNameAsParams(toupleWithName);

        created.TouplesAsParams(toupleWithoutName);
        created.TouplesAsParams(toupleWithName);

        Console.ReadLine();
        Console.Clear();
    }
}
