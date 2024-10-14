using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E06.FoodShortage
{
    public abstract class Human : IBuyer
    {
        protected Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }

        public abstract void BuyFood();
    }
}
