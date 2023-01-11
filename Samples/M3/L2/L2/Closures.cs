namespace L2;

internal static class Closures
{
    public static void Execute()
    {
        var iAmInt = 10;

        Action increment = () => iAmInt++;
        increment(); // ??

        var listOfActions = new List<Action>();
        for (var i = 0; i < 3; i++)
        {
            listOfActions.Add(() => Console.WriteLine(i));
        }

        foreach (var action in listOfActions) action(); //??
    }
}
