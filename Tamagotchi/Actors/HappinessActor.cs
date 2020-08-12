using System;
using Akka.Actor;
using Tamagotchi.Events;

namespace Tamagotchi.Actors
{
    public sealed class HappinessActor : ReceiveActor
    {
        public HappinessActor()
        {
            Receive<DragonAte>(ate =>
            {
                ate.Dragon.IncreaseHappiness();
                Console.WriteLine($"{ate.Dragon.Name}'s happiness level is {ate.Dragon.Happiness}");
            });

            Receive<DragonNotEating>(notEating =>
            {
                notEating.Dragon.DecreaseHappiness();
                Console.WriteLine($"{notEating.Dragon.Name}'s happiness level is {notEating.Dragon.Happiness}");
            });
        }
    }
}
