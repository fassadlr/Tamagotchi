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
                var healthReport = new HealthReport
                {
                    Message = e.Dragon.ToString()
                };

                if (e.Dragon.Happiness <= 0)
                {
                    healthReport.Alive = false;
                    healthReport.Message = $"{e.Dragon.Name} died of loneliness.";
                    Sender.Tell(healthReport);

                    return;
                }

                if (e.Dragon.Hunger >= Dragon.MaximumHunger)
                {
                    healthReport.Alive = false;
                    healthReport.Message = $"{e.Dragon.Name} died of hunger.";
                    Sender.Tell(healthReport);

                    return;
                }

                e.Dragon.GrowOlder();

                Sender.Tell(healthReport);
            });
        }
    }
}
