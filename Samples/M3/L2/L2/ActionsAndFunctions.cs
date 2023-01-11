namespace L2;

internal static class ActionsAndFunctions
{
    public static Action ActionHandler;
    public static Func<int> FuncHandler;
    public static Predicate<int> PredicateHandler;

    public static void Execute()
    {
        // ACTION -> no return (void)
        Action xAction = () => Console.WriteLine("Empty action");
        Action<int> yAction = (int p) => Console.WriteLine($"Action with param");
        var zAction = () => Console.WriteLine("Var action");

        // FUNC -> last T is a return type
        Func<int> xFunc = () => 1;
        Func<int, string> yFunct = (int p) => "Hello Function";
        var zFunc = (int p, int p2) => 0.01M;

        // PREDICATE -> returns boolean, takes 1 parameter
        Predicate<int> xPredicate = (int p) => p > 0;
    }
}
