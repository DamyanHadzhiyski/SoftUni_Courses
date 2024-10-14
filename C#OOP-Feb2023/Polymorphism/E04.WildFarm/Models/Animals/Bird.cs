using E04.WildFarm.Factories;
using E04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Models.Animals
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
            => base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
    }
}
