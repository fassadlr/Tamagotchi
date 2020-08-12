using System;
using Akka.Actor;
using Tamagotchi.Messages;

namespace Tamagotchi.Actors
{
    public sealed class HungerActor : ReceiveActor
    {
        public HungerActor()
        {
            Receive<FeedDragon>(e =>
            {
                if (Context.System.WhenTerminated.IsCompleted)
                    return;

                //e.Dragon.DecreaseHunger();
                Console.WriteLine($"{e.Dragon.Name} ate, hunger is now {e.Dragon.Hunger}");
            });

            Receive<StarveDragon>(e =>
            {
                if (Context.System.WhenTerminated.IsCompleted)
                    return;

                //e.Dragon.IncreaseHunger();
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