﻿using System.Text;

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

        private string lastAction;

        public Dragon(string name)
        {
            Name = name;
            Happiness = 100;
        }

        public void DecreaseHappiness(int factor)
        {
            if (Happiness > 0)
                Happiness -= factor;
        }

        public void IncreaseHappiness(int factor)
        {
            if ((Happiness + factor) > MaximumHappiness)
                Happiness = MaximumHappiness;

            if (Happiness < MaximumHappiness)
                Happiness += factor;

            lastAction = "Your dragon's happiness improved.";
        }

        public void DecreaseHunger(int factor)
        {
            if (Hunger - factor < 0)
                Hunger = 0;

            if (Hunger > 0)
                Hunger -= factor;

            lastAction = "You dragon's hunger decreased.";
        }

        public void IncreaseHunger(int factor)
        {
            if (Hunger < MaximumHunger)
                Hunger += factor;
        }

        public void GrowOlder()
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

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            if (Age < 1)
                message.AppendLine($"{Name} is a {monthsToNextAge} month old {Stage.ToString()} and is still alive.");
            else
                message.AppendLine($"{Name} is a {Age} year old {Stage.ToString()} and is still alive.");

            message.AppendLine(lastAction);
            lastAction = null;

            message.AppendLine($"Happiness: {Happiness} Hunger: {Hunger}");

            if (Happiness <= 30)
                message.AppendLine($"{Name} is getting very lonely...");

            if (Hunger >= 70)
                message.AppendLine($"{Name} is getting very hungry...");

            return message.ToString();
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
