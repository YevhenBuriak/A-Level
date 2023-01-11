namespace L2;

// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/how-to-declare-instantiate-and-use-a-delegate
internal static class Anonymous
{
    public delegate int Do(int left, int right);
    public delegate void Void();

    public static void Execute()
    {
        // anonymous function
        Do delAnonymous = delegate (int a, int b)
        {
            return a + b;
        };

        // lambda function
        Do delLambda = (int a, int b) => a * b;
        delLambda += (int a, int b) =>
        {
            return a + b;
        };

        Void v = () => Console.Clear();

        var anonymousResult = delLambda.Invoke(2, 3);
        var lambdaResult = delLambda(2, 3);
        v();
    }
}
