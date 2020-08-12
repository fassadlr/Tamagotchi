using System;
using Akka.Actor;
using Tamagotchi.Messages;

namespace Tamagotchi.Actors
{
    public sealed class DragonActor : ReceiveActor
    {
        public DragonActor(LifeMetricProcessor lifeMetricProcessor)
        {
            Receive<FeedDragon>(e =>
            {
                lifeMetricProcessor.Feed();
            });

            Receive<StarveDragon>(e =>
            {
                lifeMetricProcessor.Starve();
            });

            Receive<PetDragon>(e =>
            {
                lifeMetricProcessor.Pet();
            });

            Receive<IgnoreDragon>(e =>
            {
                lifeMetricProcessor.Ignore();
            });

            Receive<HealthCheck>(e =>
            {
                if (e.Dragon.Happiness <= 30)
                    Console.WriteLine($"{e.Dragon.Name} is getting very lonely.");

                if (e.Dragon.Hunger >= 70)
                    Console.WriteLine($"{e.Dragon.Name} is getting very hungry.");

                if (e.Dragon.Happiness <= 0)
                {
                    Console.WriteLine($"{e.Dragon.Name} died of loneliness.");
                    Context.System.Terminate();
                    return;
                }

                if (e.Dragon.Hunger >= Dragon.MaximumHunger)
                {
                    Console.WriteLine($"{e.Dragon.Name} died of hunger.");
                    Context.System.Terminate();
                }

                e.Dragon.GrowOlder();

                Console.WriteLine($"{e.Dragon.Name} is a {e.Dragon.Age} year old {e.Dragon.Stage.ToString()} and is doing well.");
            });
        }
    }
}
