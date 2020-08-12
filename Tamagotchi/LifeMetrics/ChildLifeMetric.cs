namespace Tamagotchi.LifeMetrics
{
    public sealed class ChildLifeMetric : LifeMetric
    {
        public ChildLifeMetric(Dragon dragon) : base(dragon)
        {
        }

        public override void Feed()
        {
            base.Dragon.DecreaseHunger(10);
        }

        public override void Pet()
        {
            base.Dragon.IncreaseHappiness(15);
        }

        public override void Ignore()
        {
            base.Dragon.DecreaseHappiness(10);
        }

        public override void Starve()
        {
            base.Dragon.IncreaseHunger(7);
        }

        public override bool IsApplicable()
        {
            return base.Dragon.Stage == LifeStage.Child;
        }
    }
}
