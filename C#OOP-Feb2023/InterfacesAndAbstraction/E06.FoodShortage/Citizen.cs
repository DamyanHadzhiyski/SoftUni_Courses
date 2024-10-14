using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E06.FoodShortage
{
    public class Citizen : Human, IIdentifiable, IBirthable
    {
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate) 
            : base(name, age)
        {
            Id = id;
            Birthdate = birthdate;
        }

        public string Id { get => id; set => id = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public bool IsFake(string lastDigits)
        {
            return this.id.EndsWith(lastDigits);
        }

        public bool BirthYearMatch(string year)
        {
            return this.birthdate.EndsWith(year);
        }

        public override void BuyFood()
        {
            Food += 10;
        }
    }
}
