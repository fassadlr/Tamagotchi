using System;
using Akka.Actor;
using Tamagotchi.Messages;

namespace Tamagotchi.Actors
{
    public sealed class DragonActor : ReceiveActor
    {
        public DragonActor()
        {
            Receive<FeedDragon>(e =>
            {
                e.Dragon.DecreaseHunger();
            });

            Receive<StarveDragon>(e =>
            {
                e.Dragon.IncreaseHunger();
            });

            Receive<PetDragon>(e =>
            {
                e.Dragon.IncreaseHappiness();
            });

            Receive<IgnoreDragon>(e =>
            {
                e.Dragon.DecreaseHappiness();
            });

            Receive<HealthCheck>(e =>
            {
                if (e.Dragon.Happiness <= 3)
                    Console.WriteLine($"{e.Dragon.Name} is getting very lonely.");

                if (e.Dragon.Hunger >= 7)
                    Console.WriteLine($"{e.Dragon.Name} is getting very hungry.");

                if (e.Dragon.Happiness == 0)
                {
                    Console.WriteLine($"{e.Dragon.Name} died of loneliness.");
                    Context.System.Terminate();
                    return;
                }

                if (e.Dragon.Hunger > 10)
                {
                    Console.WriteLine($"{e.Dragon.Name} died of hunger.");
                    Context.System.Terminate();
                }

                e.Dragon.GrowOlder();

                Console.WriteLine($"{e.Dragon.Name} is a {e.Dragon.Age} year old {e.Dragon.LifeStage} and is doing well.");
            });
        }
    }
}
