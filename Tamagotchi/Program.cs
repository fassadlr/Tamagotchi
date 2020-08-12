using System;
using System.Threading.Tasks;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Imburse!");
            Console.WriteLine("This is Tamagotchi.Akka.Net");
            Console.WriteLine("How long should a month in Tamagotchi's life be in seconds?");

            int intervalSeconds;
            do
            {
                Console.WriteLine("Please enter a value in seconds (max 60)");
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

            Console.WriteLine($"{name}'s life is beginning...");

            var dragon = new Dragon(name);
            var life = new Life(dragon);
            life.Begin();

            do
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                        break;

                    if (key == ConsoleKey.F)
                        life.Feed();
                }
                else
                {
                    if (life.Ended.IsCompleted)
                        break;

                    Console.Clear();
                    life.Progress();
                    Console.WriteLine("Press F to feed, Esc to Quit");
                    Task.Delay(TimeSpan.FromSeconds(intervalSeconds)).GetAwaiter().GetResult();
                }
            } while (true);

            life.End();
            Console.WriteLine($"{name}'s life ended.");

            life.Ended.Wait();
        }
    }
}
