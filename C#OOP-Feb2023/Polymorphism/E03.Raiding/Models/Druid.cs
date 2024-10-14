using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03.Raiding.Models
{
    public class Druid : Hero
    {
        private const int power = 80;

        public Druid(string name) 
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
