﻿using System;
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

            var dragonActor = Sys.ActorOf(Props.Create(() => new DragonActor(lifeMetricProcessor)));

            // Starve the dragon until it dies of hunger.
            dragon.IncreaseHunger(100);

            // Do a health check on the dragon.
            dragonActor.Tell(new HealthCheck(dragon));
            Assert.False(ExpectMsg<HealthReport>().Alive);
        }

        [Fact]
        public void Dragon_CanDieOf_Loneliness()
        {
            // Create a dragon.
            var dragon = new Dragon("test");

            // Create the life metric processor.
            var lifeMetricProcessor = new LifeMetricProcessor(dragon);

            var dragonActor = Sys.ActorOf(Props.Create(() => new DragonActor(lifeMetricProcessor)));

            // Starve the dragon until it dies of hunger.
            dragon.DecreaseHappiness(100);

            // Do a health check on the dragon.
            dragonActor.Tell(new HealthCheck(dragon));
            Assert.False(ExpectMsg<HealthReport>().Alive);
        }

        [Fact]
        public void Dragon_CanDie_ViaLifeActor()
        {
            // Create a dragon.
            var dragon = new Dragon("test");

            // Create the life metric processor.
            var lifeMetricProcessor = new LifeMetricProcessor(dragon);

            var dragonActor = Sys.ActorOf(Props.Create(() => new DragonActor(lifeMetricProcessor)));
            var lifeActor = Sys.ActorOf(Props.Create(() => new LifeActor(dragonActor)));

            // Starve the dragon until it dies of hunger.
            dragon.IncreaseHunger(100);

            // Do a health check on the dragon.
            lifeActor.Tell(new HealthCheck(dragon));

            Watch(lifeActor);
            ExpectMsg<Terminated>(TimeSpan.FromSeconds(5));
            Watch(dragonActor);
            ExpectMsg<Terminated>(TimeSpan.FromSeconds(5));
        }
    }
}
