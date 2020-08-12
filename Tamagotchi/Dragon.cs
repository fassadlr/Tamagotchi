namespace Tamagotchi
{
    public sealed class Dragon
    {
        public readonly string Name;

        public int Age { get; private set; }
        public int Weight { get; private set; }
        public int Happiness { get; private set; }
        public int Hunger { get; private set; }

        public Dragon(string name)
        {
            Name = name;
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
    }
}
