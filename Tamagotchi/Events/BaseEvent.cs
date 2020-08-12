namespace Tamagotchi.Events
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
