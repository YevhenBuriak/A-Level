namespace L4;

public static class Liskov
{
    public static void Execute()
    {
        var shape = new Shape() { SideA = 10, SideB = 20 };
        var rectangle = new Rectangle() { SideA = 10 };
        PrintArea(shape);
        PrintArea(rectangle);
    }

    public static void PrintArea(Shape shape)
    {
        Console.WriteLine(shape.Sum());
        Console.WriteLine(shape.SideA);
        Console.WriteLine(shape.SideB);
        Console.WriteLine(shape.Area());

        Console.ReadLine();
        Console.Clear();
    }

    public class Shape
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public virtual int Area() => SideA * SideB;
        public virtual int Sum() => SideA + SideB;
    }

    public class Rectangle : Shape
    {
        public override int Area() => SideA * 2;
        public override int Sum() => throw new ArgumentException();
    }
}
