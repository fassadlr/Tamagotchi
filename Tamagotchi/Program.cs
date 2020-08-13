using System;
using System.Threading.Tasks;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Imburse and welcome to Tamagotchi.Akka.Net!");
            Console.WriteLine();

            RunGame(SetAgingIntervalInSeconds(), SetDragonName());
        }

        private static void RunGame(int intervalSeconds, string name)
        {
            Console.WriteLine($"{name}'s life began...");

            var dragon = new Dragon(name);
            var life = new Life(dragon);
            life.Begin();

            do
            {
                Console.Clear();

                if (life.Ended.IsCompleted)
                    break;

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                        break;

                    if (key == ConsoleKey.F)
                        life.Feed();

                    if (key == ConsoleKey.P)
                        life.Pet();
                }
                else
                {
                    Console.WriteLine("Press F to feed, P to Pet or Esc to Quit");
                    Console.WriteLine();

                    life.Progress();

                    Task.Delay(TimeSpan.FromSeconds(intervalSeconds)).GetAwaiter().GetResult();
                }
            } while (true);

            life.End();
            life.Ended.Wait();

            Console.WriteLine($"GAME OVER");
            Console.WriteLine($"Press any key...");
            Console.ReadKey();
        }

        private static int SetAgingIntervalInSeconds()
        {
            Console.WriteLine("How long should a month in Tamagotchi's life be in seconds?");

            int intervalSeconds;
            do
            {
                Console.WriteLine("Please enter a value (max 60):");
                var interval = Console.ReadLine();
                if (!int.TryParse(interval, out intervalSeconds))
                {
                    Console.WriteLine("Invalid, please enter a number between 0 and 60.");
                    continue;
                }

                if (intervalSeconds > 60 || intervalSeconds < 0)
                {
                    Console.WriteLine("Invalid, please enter a value between 0 and 60.");
                    continue;
                }

                break;
            } while (true);

            return intervalSeconds;
        }

        private static string SetDragonName()
        {
            string name;
            do
            {

                Console.WriteLine("Please enter a name for your Tamagotchi dragon:");
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                    break;

                continue;
            }
            while (true);

            return name;
        }
    }
}
