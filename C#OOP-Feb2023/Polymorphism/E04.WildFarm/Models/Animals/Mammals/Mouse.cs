using E04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double gainFactor = 0.1;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> { typeof(Vegetable), typeof(Fruit) };

        protected override double WeightMultiplier 
            => gainFactor;

        public override string ProduceSound()
            => "Squeak";

        public override string ToString()
            => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
