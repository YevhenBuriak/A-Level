namespace L2;

//Delegates: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
internal static class Delegates
{
    // delegates declaration:

    public delegate void Void();
    public delegate int IntHandler();
    public delegate int ParamsHandler(int left, int right);

    public static void Execute()
    {
        var c = new ClassWithMethods();

        // add methods
        Void voidDelegateFromClass = c.WriteHello;
        Void voidDelegateFromStatic = StaticClassWithMethods.WriteGoodby;



        // invocation
        //voidDelegateFromClass.Invoke();
        //// or
        //voidDelegateFromStatic();

        //// invocation with params
        ///
        ParamsHandler intDelegateFromClass = c.Add;
        intDelegateFromClass += c.Multiply;
        var x = intDelegateFromClass.Invoke(3, 3);
        //// or
        //var sum2 = intDelegateFromClass(1, 2);

        //Console.Clear();

        // multiple methods
        voidDelegateFromClass += c.WriteHello;
        voidDelegateFromClass += c.WriteHello;

        voidDelegateFromClass.Invoke();
        // or
        //voidDelegateFromClass();

        //Console.WriteLine(voidDelegateFromClass.GetInvocationList()?.Length);
        Console.Clear();

        // remove method

        voidDelegateFromClass -= c.WriteHello;

        voidDelegateFromClass?.Invoke();

        Console.WriteLine(voidDelegateFromClass?.GetInvocationList()?.Length);
        Console.Clear();

        var x2 = new { Value = (int?)null };
        if (x2.Value > 0)
        {

        }

        // Write your own delegate that accepts 1-2 parms and returns any type. Add methods, Remove and Invoke (15 mins)
    }

    public class ClassWithMethods
    {
        public void WriteHello()
        {
            Console.WriteLine("Hello");
        }

        public int Add(int left, int right)
        {
            return left + right;
        }

        public int Multiply(int left, int right)
        {
            return left * right;
        }
    }

    public static class StaticClassWithMethods
    {
        public static void WriteGoodby()
        {
            Console.WriteLine("Goodby");
        }
    }
}
