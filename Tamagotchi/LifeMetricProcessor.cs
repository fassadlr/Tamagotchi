using System.Collections.Generic;
using System.Linq;
using Tamagotchi.LifeMetrics;

namespace Tamagotchi
{
    public sealed class LifeMetricProcessor
    {
        private readonly List<LifeMetric> metrics = new List<LifeMetric>();

        public LifeMetricProcessor(Dragon dragon)
        {
            metrics.Add(new BabyLifeMetric(dragon));
            metrics.Add(new ChildLifeMetric(dragon));
            metrics.Add(new TeenLifeMetric(dragon));
            metrics.Add(new AdultLifeMetric(dragon));
        }

        public void Feed()
        {
            var strategy = metrics.First(s => s.IsApplicable());
            strategy.Feed();
        }

        internal void Starve()
        {
            var strategy = metrics.First(s => s.IsApplicable());
            strategy.Starve();
        }

        internal void Ignore()
        {
            var strategy = metrics.First(s => s.IsApplicable());
            strategy.Ignore();
        }

        public void Pet()
        {
            var strategy = metrics.First(s => s.IsApplicable());
            strategy.Pet();
        }
    }

    public abstract class LifeMetric
    {
        protected readonly Dragon Dragon;

        protected LifeMetric(Dragon dragon)
        {
            this.Dragon = dragon;
        }

        public abstract bool IsApplicable();

        public abstract void Feed();
        public abstract void Starve();

        public abstract void Ignore();
        public abstract void Pet();
    }
}
