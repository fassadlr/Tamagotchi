using Akka.Actor;
using Akka.TestKit.Xunit;
using Tamagotchi.Actors;
using Tamagotchi.Messages;
using Xunit;

namespace Tamagotchi.Tests
{
    public sealed class BabyDragonActorTests : TestKit
    {
        [Fact]
        public void DragonActor_CanIncreaseAndDecrease_Happiness_Baby()
        {
            // Create a dragon.
            var dragon = new Dragon("test");

            // Create the life metric processor.
            var lifeMetricProcessor = new LifeMetricProcessor(dragon);

            var dragonActorRef = Sys.ActorOf(Props.Create(() => new DragonActor(lifeMetricProcessor)));

            // Ignore the dragon so that happiness decreases.
            dragonActorRef.Tell(new IgnoreDragon(dragon));
            ExpectNoMsg();
            Assert.Equal(95, dragon.Happiness);

            // Pet the dragon so that it's happiness increases.
            dragonActorRef.Tell(new PetDragon(dragon));
            ExpectNoMsg();
            Assert.Equal(100, dragon.Happiness);

            Sys.Terminate();
        }

        [Fact]
        public void DragonActor_CanIncreaseAndDecrease_Hunger_Baby()
        {
            // Create a dragon.
            var dragon = new Dragon("test");

            // Create the life metric processor.
            var lifeMetricProcessor = new LifeMetricProcessor(dragon);

            var dragonActorRef = Sys.ActorOf(Props.Create(() => new DragonActor(lifeMetricProcessor)));

            // Starve the dragon so that it's hunger increases.
            dragonActorRef.Tell(new StarveDragon(dragon));
            ExpectNoMsg();
            Assert.Equal(10, dragon.Hunger);

            // Feed the dragon so that it's hunger decreases.
            dragonActorRef.Tell(new FeedDragon(dragon));
            ExpectNoMsg();
            Assert.Equal(0, dragon.Hunger);

            Sys.Terminate();
        }
    }
}
