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
                var healthReport = new HealthReport();

                if (e.Dragon.Happiness <= 30)
                    healthReport.Message = $"{e.Dragon.Name} is getting very lonely.";

                if (e.Dragon.Hunger >= 70)
                    healthReport.Message = $"{e.Dragon.Name} is getting very hungry.";

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

                if (healthReport.Message == null)
                {
                    healthReport.Message = $"{e.Dragon.Name} is a {e.Dragon.Age} year old {e.Dragon.Stage.ToString()} and is doing well.";
                }
                else
                    healthReport.Message += $"\r\n{e.Dragon.Name} is a {e.Dragon.Age} year old {e.Dragon.Stage.ToString()} and is doing well.";

                Sender.Tell(healthReport);
            });
        }
    }
}
