namespace L2;

internal static class Closures
{
    public static void Execute()
    {
        var iAmInt = 10;

        Action increment = () =>
        {
            iAmInt++;
        };

        increment(); // ??

        var listOfActions = new List<Action>();
        for (var i = 0; i < 3; i++)
        {
            var j = i;
            listOfActions.Add(() => Console.WriteLine(j));
        }

        foreach (var action in listOfActions) action();
    }


    /*
     * 1. Action -> add, 2 parameters, anon f => 
     * 2. Func -> multiply, 2 parameters + 1 from outside scope => 
     */

}
