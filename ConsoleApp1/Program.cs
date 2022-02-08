using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ds a
            //dsdasd
            ///3333
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой");
            Console.ForegroundColor = oldColor;

            int Health = 1000;
            int Armor = 20;

            bool isRandomAttack = (DateTime.Now.Millisecond % 2) == 0;

            oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Босс будет атаковать: " + (isRandomAttack ? "случайно" : "все атаки по очереди"));
            Console.ForegroundColor = oldColor;

            oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Нажмите enter для начала боя");
            Console.ForegroundColor = oldColor;
            Console.ReadLine();

            int attackNumber = 0;
            while (Health > 0)
            {
                Console.Clear();
                oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("У вас здоровья: " + Health);
                Console.ForegroundColor = oldColor;

                if (isRandomAttack)
                {
                    int rand = DateTime.Now.Millisecond % 3;
                    if (rand == 0)
                    {
                        oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Босс атаковал с немыслимой яростью своими руками");
                        Console.ForegroundColor = oldColor;

                        Health = Health - (100 - Armor);
                    }
                    else if (rand == 1)
                    {
                        oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Босс исполнил новый альбом Ольги бузовой");
                        Console.ForegroundColor = oldColor;
                        Health = Health - (140 - Armor);
                    }
                    else if (rand == 2)
                    {
                        oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Босс приуныл и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки");
                        Console.ForegroundColor = oldColor;
                        Health = Health - (80 - Armor);
                    }
                }
                else
                {
                    if (attackNumber == 0)
                    {
                        oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Босс атаковал с немыслимой яростью своими руками");
                        Console.ForegroundColor = oldColor;

                        Health = Health - (100 - Armor);
                    }
                    else if (attackNumber == 1)
                    {
                        oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Босс исполнил новый альбом Ольги бузовой");
                        Console.ForegroundColor = oldColor;
                        Health = Health - (140 - Armor);
                    }
                    else if (attackNumber == 2)
                    {
                        oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Босс паник и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки");
                        Console.ForegroundColor = oldColor;
                        Health = Health - (80 - Armor);
                    }

                    attackNumber += 1;
                    if (attackNumber > 2)
                    {
                        attackNumber = 0;
                    }
                }

                Thread.Sleep(4000);
            }

            oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Бой закончен, вы погибли");
            Console.ForegroundColor = oldColor;

        }
    }
}

