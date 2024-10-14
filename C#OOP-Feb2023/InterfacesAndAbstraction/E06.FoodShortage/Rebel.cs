using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E06.FoodShortage
{
    public class Rebel : Human
    {
        public Rebel(string name, int age, string group)
            : base(name, age)
        {
            Group = group;
        }

        public string Group { get; set; }

        public override void BuyFood()
        {
            Food += 5;
        }
    }
}
