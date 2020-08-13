namespace Tamagotchi.LifeMetrics
{
    public sealed class BabyLifeMetric : LifeMetric
    {
        public BabyLifeMetric(Dragon dragon) : base(dragon)
        {
        }

        public override void Feed()
        {
            Dragon.DecreaseHunger(10);
        }

        public override void Pet()
        {
            Dragon.IncreaseHappiness(20);
        }

        public override void Ignore()
        {
            Dragon.DecreaseHappiness(5);
        }

        public override void Starve()
        {
            Dragon.IncreaseHunger(10);
        }

        public override bool IsApplicable()
        {
            return Dragon.Stage == LifeStage.Baby;
        }
    }
}
