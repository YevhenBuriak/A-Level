namespace L1;

//Structs: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct

public struct SimpleCoordinatesStruct
{
    private short _dimension = 2;
    public decimal X { get; set; }
    public decimal Y { get; set; } = 0;

    public SimpleCoordinatesStruct(decimal x = 0, decimal y = 0)
    {
        X = x;
        Y = y;
    }

    public static SimpleCoordinatesStruct operator +(SimpleCoordinatesStruct a, SimpleCoordinatesStruct b)
    {
        return new SimpleCoordinatesStruct(a.X + b.X, a.Y + b.Y);
    }
}
