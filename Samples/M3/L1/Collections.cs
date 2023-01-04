using System.Collections;

namespace L1;

// Collections: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections
internal static class Collections
{
    public static void Execute()
    {
        // ArrayList
        var list = new ArrayList() { 1, 2, 3, 4 };
        list.Add(5);
        list.AddRange(new[] { 6, 7 });
        list.Insert(0, 0);
        list.Remove(5);
        list.Reverse();
        list.BinarySearch(3);

        _ = list[0];

        // HashSet
        var hs = new Hashtable
        {
            { "green", 0 },
            { "red", 1 }
        };
        hs.Add("blue", 2);
        hs.Add("green", 1); // !

        _ = hs.Values;
        _ = hs.Keys;
        _ = hs.ContainsKey("green");
        _ = hs.ContainsValue(1);
        _ = hs["green"];

        // Queue (FIFO)
        var q = new Queue();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);

        q.Dequeue(); // ?
        q.Peek(); // ?
        q.Dequeue(); // ?

        _ = q.Count;

        // Stack (LIFO)
        var s = new Stack();
        s.Push(1);
        s.Push(2);
        s.Push(3);

        s.Pop(); // ?
        s.Peek(); // ?
        s.Pop(); // ?

        _ = s.Count;
    }
}
