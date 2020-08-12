using System;
using Akka.Actor;
using Tamagotchi.Events;

namespace Tamagotchi.Actors
{
    public sealed class HungerActor : ReceiveActor
    {
        public HungerActor()
        {
            Receive<DragonAte>(e =>
            {
                e.Dragon.DecreaseHunger();
                Console.WriteLine($"{e.Dragon.Name} ate, hunger is now {e.Dragon.Hunger}");
            });

            Receive<DragonNotEating>(e =>
            {
                e.Dragon.IncreaseHunger();
                if (e.Dragon.Hunger > 10)
                {
                    Console.WriteLine($"{e.Dragon.Name} died of hunger.");
                    Context.System.Terminate();
                }

                Console.WriteLine($"{e.Dragon.Name} did not eat, hunger is now {e.Dragon.Hunger}");
            });
        }
    }
}