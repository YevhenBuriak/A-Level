namespace L1;

internal static class GenericCollections
{
    public static void Execute()
    {
        //List

        var list = new List<int>() { 1, 2, 3 };
        var lists = new List<string>() { "first", "second" };

        list.Add(4);
        list.RemoveAt(0);
        list.Sort();

        _ = list.ToArray();
        _ = list.Capacity;
        _ = list.Count;
        _ = list[0];

        //LinkedList
        var alist = new LinkedList<int>();
        alist.AddLast(1);
        alist.AddLast(2);
        alist.AddFirst(0);
        alist.RemoveLast();

        _ = alist.Count;

        //HashSet
        var hs = new HashSet<int>();
        hs.Add(1);
        hs.Add(2);

        _ = hs.Contains(1);

        //Dictionary
        var dc = new Dictionary<int, string>()
        {
            { 1, "hello" },
            { 2, "world" }
        };

        dc.Add(3, "volondemort");
        dc.Add(2, "underworld");

        _ = dc.TryAdd(2, "underworld");
        _ = dc.Values;
        _ = dc.ContainsKey(2);
        _ = dc[2];
        _ = dc.TryGetValue(4, out var value);

        //Stack
        //Queue
    }
}
