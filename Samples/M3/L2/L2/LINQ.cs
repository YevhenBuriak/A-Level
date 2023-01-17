//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
namespace L2;

internal static class LINQ
{
    public static void Execute()
    {
        var list = new List<int>() { 1, 2, 3 };

        var query = list.Where2(i => i % 2 == 0).ToList(); // 2
        // false

        list.Any(i => i % 2 == 0); // true
        list.All(i => i % 2 == 0);
        list.First(i => i == 3); // 3
        //list.Single(i => i == 4); // exception
        list.Sum();
        list.ToArray();
        list.ToList();
        list.FirstOrDefault();
        list.SingleOrDefault();
        list.Last(x => x > 1);
        list.LastOrDefault();
        list.Max();
        list.Min();
    }
}

public static class Ext
{
    public static IEnumerable<T> Where2<T>(this IEnumerable<T> src, Func<T, bool> func)
    {
        foreach (var item in src)
        {
            if (func(item))
            {
                yield return item;
            }
        }
    }
}