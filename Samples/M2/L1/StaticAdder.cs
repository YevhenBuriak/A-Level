namespace L1;

//Static classes: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
public static class StaticAdder
{
    private static int _staticValue;

    public static int StaticValue
    {
        get { return _staticValue; }
        set { _staticValue = value; }
    }

    static StaticAdder()
    {
        _staticValue = 0;
    }

    public static int Add(int first, int second)
    {
        return first + second;
    }

    public static int Add(int first)
    {
        return first + _staticValue;
    }

    public static int Add(int inital = 0, params int[] values)
    {
        var result = inital;

        for (var i = 0; i < values.Length; i++)
        {
            result += values[i];
        }

        return result;
    }

    public static string Add(string first, string second)
    {
        return string.Concat(first, " ", second);
    }
}
