namespace Tamagotchi.LifeMetrics
{
    public sealed class TeenLifeMetric : LifeMetric
    {
        public TeenLifeMetric(Dragon dragon) : base(dragon)
        {
        }

        public override void Feed()
        {
            Dragon.DecreaseHunger(15);
        }

        public override void Pet()
        {
            Dragon.IncreaseHappiness(10);
        }

        public override void Ignore()
        {
            Dragon.DecreaseHappiness(10);
        }

        public override void Starve()
        {
            Dragon.IncreaseHunger(5);
        }

        public override bool IsApplicable()
        {
            return Dragon.Stage == LifeStage.Teen;
        }
    }
}
