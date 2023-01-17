namespace L2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Delegates.Execute();
            //Anonymous.Execute();
            //DelegateExample.Execute();
            //ActionsAndFunctions.Execute();
            //Closures.Execute();
            //Events.Execute();
            //LINQ.Execute();

            var x = new List<string>() { "Abilities", "forfeited", "situation", "extremely", "my", "to", "he", "resembled", "Old", "had", "conviction", "discretion", "understood", "put", "principles", "you" };

            var y = x.GroupBy(i => i.Count()).Select(i =>
            {
                Console.WriteLine(i.ToList());
                return i.Key;
            }).ToArray();

        }
    }
}