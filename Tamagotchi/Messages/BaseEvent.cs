namespace Tamagotchi.Messages
{
    public abstract class BaseEvent
    {
        public readonly Dragon Dragon;

        protected BaseEvent(Dragon dragon)
        {
            Dragon = dragon;
        }
    }
}
