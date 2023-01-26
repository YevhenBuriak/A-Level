namespace L4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            //Base x = new Base();
            //Base y = new Derived();

            //x.DoSomething();  // Prints: Doing from Base
            //y.DoSomething();  // Prints: Doing from Derived

            // 2
            //Base x = new Base();
            //Base y = new Derived();

            //x.DoSomething();  // Prints: Doing from Base
            //y.DoSomething();  // Prints: Doing from Derived
            ////y.DoMore(); // Does not work

            //Derived z = new Derived();
            //z.DoMore();       // Prints: Doing more from Derived
            //z.DoSomething();  // Prints: Doing from Derived

            //// Base (left) = Base (right) // access to base methods
            //// Base (left) = Derived (right) // access to base methods
            //// Derived (left) = Derived (right) // access to base methods + access to derived methods

            // 3
            // assignment
            //IProduce<Base> prodOfBase = new Producer<Base>();
            //IProduce<Derived> prodOfDerived = new Producer<Derived>();

            //IProduce<Base> prodOfDerived2 = new Producer<Derived>(); // NO, default invariance, cannot cast Derived to Base
            //IProduce<Derived> prodOfDeriver2 = new Producer<Base>(); // NO, default invariance, cannot cast Base to Derived

            //// product:

            //Base x = prodOfBase.Produce(); // returns Base which is Base
            //Base x2 = prodOfDerived.Produce(); // returns Derived which is Base
            //Derived z = prodOfDerived.Produce(); // return Derived which is derived
            //Derived y = prodOfBase.Produce(); // NO

            //prodOfBase.Consume(new Base());
            //prodOfBase.Consume(new Derived());
            //prodOfDerived.Consume(new Derived());
            //prodOfDerived.Consume(new Base()); //NO


            //4
            //assignment difference
            IProduce<Base> prodOfBase = new Implementer<Base>();
            IProduce<Derived> prodOfDerived = new Implementer<Derived>();
            IProduce<Base> prodOfDerived2 = new Implementer<Derived>(); // NOW OK
            IProduce<Derived> prodOfBase2 = new Implementer<Base>(); // NO

            IConsumer<Base> consOfBase = new Implementer<Base>();
            IConsumer<Derived> consOfDerived = new Implementer<Derived>();
            IConsumer<Base> consOfDerived2 = new Implementer<Derived>(); // NO
            IConsumer<Derived> consOfBase2 = new Implementer<Base>(); // NOW OK

        }

        // 1
        //class Base
        //{
        //    public void DoSomething() =>
        //      Console.WriteLine(
        //        $"Doing from {this.GetType().Name}");
        //}

        //class Derived : Base { }

        // 2 + 3 + 4
        class Base
        {
            public void DoSomething() =>
              Console.WriteLine(
                $"Doing from {this.GetType().Name}");
        }

        class Derived : Base
        {
            public void DoMore() =>
              Console.WriteLine(
                $"Doing more from {this.GetType().Name}");
        }

        // 3
        //public interface IProduce<T>
        //{
        //    T Produce();
        //    void Consume(T param);
        //}

        //class Producer<T> : IProduce<T>
        //{
        //    public void Consume(T param)
        //    {

        //    }

        //    public T Produce() => default;
        //}

        //4

        public interface IProduce<out T> // COvariant: outputs T or any derivative
        {
            T Produce();
        }

        public interface IConsumer<in T> // CONTRAvariant: T or any derivative class
        {
            void Consume(T param);
        }

        class Implementer<T> : IProduce<T>, IConsumer<T>
        {
            public void Consume(T param)
            {

            }

            public T Produce() => default;
        }


        /*

            //Covariance of return types: OK
            class Monkey { Monkey clone() }
            class Human extends Monkey { Human clone() }
 
            Monkey m = new Human();
            Monkey m2 = m.clone(); //You get a Human instance, which is ok,
                                   //since a Human is-a Monkey.
 
            //Contravariance of return types: NOT OK
            class Fruit
            class Orange extends Fruit
 
            class KitchenRobot { Orange make() }
            class Mixer extends KitchenRobot { Fruit make() }
 
            KitchenRobot kr = new Mixer();
            Orange o = kr.make(); //Orange expected, but got a fruit (too general!)
 
            //Contravariance of parameter types: OK
            class Food
            class FastFood extends Food
 
            class Person { eat(FastFood food) }
            class FatPerson extends Person { eat(Food food) }
 
            Person p = new FatPerson();
            p.eat(new FastFood()); //No problem: FastFood is-a Food, which FatPerson eats.
 
            //Covariance of parameter types: NOT OK
            class Person { eat(Food food) }
            class FatPerson extends Person { eat(FastFood food) }
 
            Person p = new FatPerson();
            p.eat(new Food()); //Oops! FastFood expected, but got Food (too general)

        */

    }
}