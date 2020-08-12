namespace Tamagotchi
{
    public sealed class Dragon
    {
        public readonly string Name;

        private int monthsToNextAge;
        public int Age { get; private set; }
        public int Weight { get; private set; }
        public int Happiness { get; private set; }
        public int Hunger { get; private set; }

        public string LifeStage
        {
            get
            {
                if (Age < 4)
                    return "Baby";

                if (Age >= 4 && Age < 8)
                    return "Child";

                if (Age >= 8 && Age < 12)
                    return "Teen";

                return "Baby";
            }
        }

        public Dragon(string name)
        {
            Name = name;
            Happiness = 10;
        }

        internal void DecreaseHappiness()
        {
            if (Happiness > 0)
                Happiness -= 1;
        }

        internal void IncreaseHappiness()
        {
            Happiness += 1;
        }

        internal void DecreaseHunger()
        {
            if (Hunger > 0)
                Hunger -= 1;
        }

        internal void IncreaseHunger()
        {
            Hunger += 1;
        }

        internal void GrowOlder()
        {
            monthsToNextAge += 1;
            if (monthsToNextAge > 12)
            {
                Age += 1;
                monthsToNextAge = 0;
            }
        }
    }
}
