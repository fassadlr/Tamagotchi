namespace Tamagotchi.LifeMetrics
{
    public sealed class BabyLifeMetric : LifeMetric
    {
        public BabyLifeMetric(Dragon dragon) : base(dragon)
        {
        }

        public override void Feed()
        {
            base.Dragon.DecreaseHunger(5);
        }

        public override void Pet()
        {
            base.Dragon.IncreaseHappiness(20);
        }

        public override void Ignore()
        {
            base.Dragon.DecreaseHappiness(5);
        }

        public override void Starve()
        {
            base.Dragon.IncreaseHunger(10);
        }

        public override bool IsApplicable()
        {
            return base.Dragon.Stage == LifeStage.Baby;
        }
    }
}
