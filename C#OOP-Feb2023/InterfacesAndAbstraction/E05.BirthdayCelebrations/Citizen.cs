using E05.BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E05.BirthdayCelebrations
{
    public class Citizen : IIdentifiable, IBirthable
    {
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
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
    }
}
