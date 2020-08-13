namespace Tamagotchi.Tests
{
    public static class TestExtensions
    {
        public static void Age(this Dragon dragon, LifeStage desiredLifeStage)
        {
            do
            {
                dragon.GrowOlder();
                if (dragon.Stage == desiredLifeStage)
                    break;
            } while (true);
        }
    }
}
