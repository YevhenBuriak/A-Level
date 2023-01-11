//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
namespace L2;

internal static class LINQ
{
    public static void Execute()
    {
        var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

        list.Select(i => i + 2); // ??
        list.Where(i => i % 2 == 0); //??
        list.Any(i => i % 2 == 0); //??
        list.Find(i => i == 3);

        var x = from i in list
                where i > 4
                select i;



    }
}
