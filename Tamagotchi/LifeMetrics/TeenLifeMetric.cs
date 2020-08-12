namespace Tamagotchi.LifeMetrics
{
    public sealed class TeenLifeMetric : LifeMetric
    {
        public TeenLifeMetric(Dragon dragon) : base(dragon)
        {
        }

        public override void Feed()
        {
            base.Dragon.DecreaseHunger(15);
        }

        public override void Pet()
        {
            base.Dragon.IncreaseHappiness(10);
        }

        public override void Ignore()
        {
            base.Dragon.DecreaseHappiness(10);
        }

        public override void Starve()
        {
            base.Dragon.IncreaseHunger(5);
        }

        public override bool IsApplicable()
        {
            return base.Dragon.Stage == LifeStage.Teen;
        }
    }
}
