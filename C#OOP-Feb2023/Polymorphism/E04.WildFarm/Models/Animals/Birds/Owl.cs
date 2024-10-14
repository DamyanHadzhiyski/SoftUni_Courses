using E04.WildFarm.Models.Food;
using E04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double gainFactor = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> { typeof(Meat) };

        protected override double WeightMultiplier 
            => gainFactor;

        public override string ProduceSound()
            => "Hoot Hoot";
    }
}
