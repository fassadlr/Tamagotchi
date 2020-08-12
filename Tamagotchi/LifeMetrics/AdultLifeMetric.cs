namespace Tamagotchi.LifeMetrics
{
    public sealed class AdultLifeMetric : LifeMetric
    {
        public AdultLifeMetric(Dragon dragon) : base(dragon)
        {
        }

        public override void Feed()
        {
            base.Dragon.DecreaseHunger(20);
        }

        public override void Pet()
        {
            base.Dragon.IncreaseHappiness(5);
        }

        public override void Ignore()
        {
            base.Dragon.DecreaseHappiness(10);
        }

        public override void Starve()
        {
            base.Dragon.IncreaseHunger(3);
        }

        public override bool IsApplicable()
        {
            return base.Dragon.Stage == LifeStage.Adult;
        }
    }
}
