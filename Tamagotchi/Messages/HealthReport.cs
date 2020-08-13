namespace Tamagotchi.Messages
{
    public sealed class HealthReport
    {
        public bool Alive { get; set; }

        public HealthReport()
        {
            Alive = true;
        }
    }
}