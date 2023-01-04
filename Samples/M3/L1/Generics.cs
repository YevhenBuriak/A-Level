using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace L1;

// Generics: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
public class Generics
{
    public static void Execute()
    {
        var adder = new Adder();
        _ = adder.AsStringPair(1, 2);
        _ = adder.AsStringPair("hello", "world");

        //

        var gIAdder = new GAdder<int>();
        var gSAdder = new GAdder<string>();

        _ = gIAdder.AsStringPair(1, 2);
        _ = gSAdder.AsStringPair("hello", "underworld");

        _ = gSAdder.MyGenericProperty;
        _ = gIAdder.MyGenericProperty;

        _ = gIAdder.GenericMethod2<int, string>("hi");
        _ = gIAdder.GenericMethod(1);
        _ = gIAdder.GenericMethod(1);

        //

        var sti = new Coords<int>();
        //var sts = new Coords<string>();
        var std = new Coords<double>();

        var wrapper = new CollectionWrapper<List<int>, int>(new List<int>());
        _ = wrapper.Print();
    }

    public class Adder
    {
        public string AsStringPair(string left, string right) => $"{left} {right}";
        public string AsStringPair(int left, int right) => $"{left} {right}";
        public string AsStringPair(double left, double right) => $"{left} {right}";

        // and so on
    }


    public class GAdder<T>
    {
        public string AsStringPair(T left, T right) => $"{left} {right}";

        // --------------------------- //

        private T? _myDefaultField = default;
        public T? MyGenericProperty { get; set; }

        public T GenericMethod(T genericParameter) => genericParameter;
        public (I?, G) GenericMethod2<I, G>(G genericParameter) => (default, genericParameter);
    }

    //public class Filtering<S> where S: 
    //    class
    //    Adder
    //    ICollection
    //    new()
    //    struct

    public struct Coords<T> where T : struct
    {
        public T X { get; set; }
        public T Y { get; set; }
    }

    public class CollectionWrapper<T, I> where T : IEnumerable<I>
    {
        public required T Collection { get; init; }

        [SetsRequiredMembers]
        public CollectionWrapper(T collection)
        {
            if (collection is null) throw new ArgumentNullException(nameof(collection));
            Collection = collection;
        }

        public string Print()
        {
            var builder = new StringBuilder(Collection.Count());

            foreach (var i in Collection)
            {
                builder.AppendLine($"item: {i}");
            }

            return builder.ToString();
        }
    }
}
