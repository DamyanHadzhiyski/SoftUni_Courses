using E04.WildFarm.Models.Food;
using E04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double gainFactor = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type> { typeof(Vegetable), typeof(Meat), typeof(Fruit), typeof(Seeds)};

        protected override double WeightMultiplier 
            => gainFactor;

        public override string ProduceSound()
            => "Cluck";
    }
}
