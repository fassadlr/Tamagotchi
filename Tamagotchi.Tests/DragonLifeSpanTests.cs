using Akka.Actor;
using Akka.TestKit.Xunit;
using Tamagotchi.Actors;
using Tamagotchi.Messages;
using Xunit;

namespace Tamagotchi.Tests
{
    public sealed class DragonLifeSpanTests : TestKit
    {
        [Fact]
        public void Dragon_CanDieOf_Hunger()
        {
            // Create a dragon.
            var dragon = new Dragon("test");

            // Create the life metric processor.
            var lifeMetricProcessor = new LifeMetricProcessor(dragon);

            var dragonActorRef = Sys.ActorOf(Props.Create(() => new DragonActor(lifeMetricProcessor)));

            // Starve the dragon until it dies of hunger.
            for (int i = 0; i < 11; i++)
            {
                dragonActorRef.Tell(new StarveDragon(dragon));
                ExpectNoMsg();
            }

            // The dragon's hunger should be at maximum.
            Assert.Equal(100, dragon.Hunger);

            // Do a health check on the dragon.
            dragonActorRef.Tell(new HealthCheck(dragon));
            Assert.False(ExpectMsg<HealthReport>().Alive);
        }

        [Fact]
        public void Dragon_CanDieOf_Loneliness()
        {
            // Create a dragon.
            var dragon = new Dragon("test");

            // Create the life metric processor.
            var lifeMetricProcessor = new LifeMetricProcessor(dragon);

            var dragonActorRef = Sys.ActorOf(Props.Create(() => new DragonActor(lifeMetricProcessor)));

            // Ignore the dragon until it dies of loneliness.
            for (int i = 0; i < 20; i++)
            {
                dragonActorRef.Tell(new IgnoreDragon(dragon));
                ExpectNoMsg();
            }

            // The dragon's hunger should be at maximum.
            Assert.Equal(0, dragon.Happiness);

            // Do a health check on the dragon.
            dragonActorRef.Tell(new HealthCheck(dragon));
            Assert.False(ExpectMsg<HealthReport>().Alive);
        }
    }
}
