namespace Tamagotchi
{
    public sealed class Dragon
    {
        public const int MaximumHappiness = 100;
        public const int MaximumHunger = 100;

        public readonly string Name;

        private int monthsToNextAge;
        public int Age { get; private set; }
        public int Weight { get; private set; }
        public int Happiness { get; private set; }
        public int Hunger { get; private set; }
        public LifeStage Stage { get; private set; }

        public Dragon(string name)
        {
            Name = name;
            Happiness = 100;
        }

        internal void DecreaseHappiness(int factor)
        {
            if (Happiness > 0)
                Happiness -= factor;
        }

        internal void IncreaseHappiness(int factor)
        {
            if (Happiness < MaximumHappiness)
                Happiness += factor;
        }

        internal void DecreaseHunger(int factor)
        {
            if (Hunger > 0)
                Hunger -= factor;
        }

        internal void IncreaseHunger(int factor)
        {
            if (Hunger < MaximumHunger)
                Hunger += factor;
        }

        internal void GrowOlder()
        {
            monthsToNextAge += 1;
            if (monthsToNextAge > 12)
            {
                Age += 1;
                monthsToNextAge = 0;
            }

            SetLifeStage();
        }

        private void SetLifeStage()
        {
            if (Age < 4)
                Stage = LifeStage.Baby;
            else if (Age >= 4 && Age < 8)
                Stage = LifeStage.Child;
            else if (Age >= 8 && Age < 12)
                Stage = LifeStage.Teen;
            else
                Stage = LifeStage.Adult;
        }
    }

    public enum LifeStage
    {
        Baby,
        Child,
        Teen,
        Adult
    }
}
