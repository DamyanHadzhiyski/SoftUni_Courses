using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03.Raiding.Models
{
    public class Paladin : Hero
    {
        private const int power = 100;

        public Paladin(string name) 
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
