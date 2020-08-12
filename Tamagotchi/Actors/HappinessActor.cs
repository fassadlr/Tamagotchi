using System;
using Akka.Actor;
using Tamagotchi.Messages;

namespace Tamagotchi.Actors
{
    public sealed class HappinessActor : ReceiveActor
    {
        public HappinessActor()
        {
            Receive<PetDragon>(e =>
            {
                //e.Dragon.IncreaseHappiness();
                Console.WriteLine($"{e.Dragon.Name}'s happiness level is {e.Dragon.Happiness}");
            });

            Receive<IgnoreDragon>(e =>
            {
                //e.Dragon.DecreaseHappiness();
                //if (e.Dragon.Happiness == 0)
                //{
                //    Console.WriteLine($"{e.Dragon.Name} died of loneliness.");
                //    Context.System.Terminate();
                //}

                Console.WriteLine($"{e.Dragon.Name}'s happiness level is {e.Dragon.Happiness}");
            });
        }
    }
}
