namespace L3;

//Extension method: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

internal static class Features
{
    public static void Execute()
    {
        //Extension methods
        var str = "My string".Escape('t');

        //Clones
        var first = new Outer()
        {
            Inner = new Inner()
            {
                InnerProperty = "Hello World"
            }
        };

        var shallowCopy = first.Copy();
        var deepCopy = first.DeepCopy();
        first.Inner.InnerProperty = "Wassap";

        //IComparable
        var array = new Comparable[3]
        {
            new() { Value = 1 },
            new() { Value = -2 },
            new() { Value = 3 }
        };

        Array.Sort(array);
    }

    public class Outer
    {
        public int OuterProperty { get; set; }
        public Inner? Inner { get; set; }

        public Outer Copy()
        {
            var shallowCopy = (Outer)MemberwiseClone();
            return shallowCopy;
        }

        public Outer DeepCopy()
        {
            var deepCopy = (Outer)MemberwiseClone();
            deepCopy.Inner = new Inner() { InnerProperty = deepCopy.Inner?.InnerProperty };
            return deepCopy;
        }
    }

    public class Inner
    {
        public string InnerProperty { get; set; }
    }

    public class Comparable : IComparable<Comparable>
    {
        public int Value { get; set; }

        int IComparable<Comparable>.CompareTo(Comparable other)
        {
            if (Value == other.Value) return 0;
            if (Value > other.Value) return 1;
            if (Value < other.Value) return -1;

            return 0;
        }
    }

}

public static class ExtensionMethods
{
    public static string Escape(this string target, char ch)
    {
        return target.Replace(ch.ToString(), $"\\{ch}");
    }
}
