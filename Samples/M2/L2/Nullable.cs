namespace L2;

// Nullable value types: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
// Nullable ref types:https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references

public static class Nullable
{
    public static void Execute()
    {
        Console.WriteLine("Example 1: non-nullable value types");

        int iAmNonNullableInt = 0;
        // iAmNonNullableInt = null;

        byte iAmNonNullableByte = 0;
        //iAmNonNullableByte = null;

        Console.WriteLine("Example 2: nullable value types");

        int? iAmNullableInt = 0;
        iAmNullableInt = null;

        Nullable<byte> iAmNullableByte = 0;
        iAmNullableByte = null;

        if (iAmNullableByte is null)
            if (iAmNullableByte == null)
                if (!iAmNullableByte.HasValue)
                {
                    Console.WriteLine("Value is null");
                }
                else
                {
                    Console.WriteLine(iAmNullableInt.Value);
                }

        Console.WriteLine("Example 3: nullable ref types");

        string implicitNullableString = "Hello";
        implicitNullableString = null; // has warning

        string? explicitNullableString = "Hello";
        explicitNullableString = null; // no warning

        Console.ReadLine();
        Console.Clear();
    }

    public static void Sygnature(int? number) { }
    public static void Sygnature(int number) { } //separate type

    public static void Sygnature(string str) { }
    //public static void Sygnature(string? str) { }//same type
}
