using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03.Raiding.Models
{
    public class Warrior : Hero
    {
        private const int power = 100;

        public Warrior(string name)
            : base (name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
