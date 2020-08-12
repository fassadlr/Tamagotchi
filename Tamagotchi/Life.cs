using System.Threading.Tasks;
using Akka.Actor;
using Tamagotchi.Actors;
using Tamagotchi.Events;
using static Akka.Actor.CoordinatedShutdown;

namespace Tamagotchi
{
    /// <summary>
    /// This class sets up and runs the actors.
    /// </summary>
    public sealed class Life
    {
        public readonly Dragon dragon;
        private ActorSystem lifeSystem;
        private IActorRef hungerActor;

        public Task Ended { get { return lifeSystem.WhenTerminated; } }

        public Life(Dragon dragon)
        {
            this.dragon = dragon;
        }

        public void Begin()
        {
            lifeSystem = ActorSystem.Create("lifeSystem");
            lifeSystem.ActorOf(Props.Create<HappinessActor>());
            hungerActor = lifeSystem.ActorOf(Props.Create<HungerActor>());
        }

        public Task End()
        {
            return Get(lifeSystem).Run(ClrExitReason.Instance);
        }

        internal void Progress()
        {
            hungerActor.Tell(new DragonNotEating(dragon));
        }

        internal void Feed()
        {
            hungerActor.Tell(new DragonAte(dragon));
        }
    }
}
