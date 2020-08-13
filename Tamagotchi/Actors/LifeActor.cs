using System;
using Akka.Actor;
using Tamagotchi.Messages;

namespace Tamagotchi.Actors
{
    public sealed class LifeActor : UntypedActor
    {
        private readonly IActorRef dragonActor;

        public LifeActor(IActorRef dragonActor)
        {
            this.dragonActor = dragonActor;
        }

        protected override void OnReceive(object message)
        {
            if (message is HealthCheck healthCheck)
            {
                dragonActor.Tell(healthCheck);
            }

            if (message is HealthReport healthReport)
            {
                Console.WriteLine(healthReport.Message);

                if (!healthReport.Alive)
                    Context.System.Terminate();
            }
        }
    }
}
