namespace Tamagotchi.Messages
{
    public sealed class PetDragon : BaseEvent
    {
        public PetDragon(Dragon dragon) : base(dragon)
        {
        }
    }
}
