using System.Threading.Tasks;
using Akka.Actor;
using Tamagotchi.Actors;
using Tamagotchi.Messages;
using static Akka.Actor.CoordinatedShutdown;

namespace Tamagotchi
{
    /// <summary>
    /// This class sets up and runs the dragon's life.
    /// </summary>
    public sealed class Life
    {
        public readonly Dragon dragon;
        private ActorSystem lifeSystem;

        private IActorRef dragonActor;
        private IActorRef lifeActor;

        public Task Ended { get { return lifeSystem.WhenTerminated; } }

        public Life(Dragon dragon)
        {
            this.dragon = dragon;
        }

        public void Begin()
        {
            lifeSystem = ActorSystem.Create("lifeSystem");

            dragonActor = lifeSystem.ActorOf(Props.Create(() => new DragonActor(new LifeMetricProcessor(dragon))), "dragonActor");
            lifeActor = lifeSystem.ActorOf(Props.Create(() => new LifeActor(dragonActor)), "lifeActor");
        }

        public Task End()
        {
            return Get(lifeSystem).Run(ClrExitReason.Instance);
        }

        internal void Progress()
        {
            dragonActor.Tell(new IgnoreDragon(dragon));
            dragonActor.Tell(new StarveDragon(dragon));

            lifeActor.Tell(new HealthCheck(dragon));
        }

        internal void Feed()
        {
            dragonActor.Tell(new FeedDragon(dragon));
        }

        internal void Pet()
        {
            dragonActor.Tell(new PetDragon(dragon));
        }
    }
}
