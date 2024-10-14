using E04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double gainFactor = 0.4;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> { typeof(Meat) };

        protected override double WeightMultiplier 
            => gainFactor;

        public override string ProduceSound()
            => "Woof!";

        public override string ToString()
            => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
