using E04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double gainFactor = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier 
            => gainFactor;

        public override string ProduceSound()
            => "Meow";
    }
}
