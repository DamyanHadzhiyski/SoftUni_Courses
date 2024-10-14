using E04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double gainFactor = 1;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> { typeof(Meat) };

        protected override double WeightMultiplier 
            => gainFactor;

        public override string ProduceSound()
            => "ROAR!!!";
    }
}
