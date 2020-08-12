namespace Tamagotchi.Messages
{
    public sealed class HealthCheck : BaseEvent
    {
        public HealthCheck(Dragon dragon) : base(dragon)
        {
        }
    }
}
