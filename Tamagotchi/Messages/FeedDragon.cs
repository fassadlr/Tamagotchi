namespace Tamagotchi.Messages
{
    public sealed class FeedDragon : BaseEvent
    {
        public FeedDragon(Dragon dragon) : base(dragon)
        {
        }
    }
}
