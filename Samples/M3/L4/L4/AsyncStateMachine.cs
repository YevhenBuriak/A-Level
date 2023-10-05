using System;
using System.Threading.Tasks;

public class C
{
    public async void M()
    {
        Console.WriteLine("Before");
        //await Task.Run(() => Console.WriteLine("hi"));
        //await Task.Run(() => Console.WriteLine("hi 2"));
        //await Task.WhenAll(Task.Run(() => Console.WriteLine("hi")), Task.Run(() => Console.WriteLine("hi")));
        Console.WriteLine("After");
    }

}