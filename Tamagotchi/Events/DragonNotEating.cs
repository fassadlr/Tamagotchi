namespace Tamagotchi.Events
{
    public sealed class DragonNotEating : BaseEvent
    {
        public DragonNotEating(Dragon dragon) : base(dragon)
        {
        }
    }
}
