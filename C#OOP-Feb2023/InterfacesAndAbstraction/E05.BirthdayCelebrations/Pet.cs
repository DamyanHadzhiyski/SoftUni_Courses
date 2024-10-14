using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E05.BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        private string birthdate;
        private string name;

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get => name; set => name = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }

        public bool BirthYearMatch(string year)
        {
            return this.birthdate.EndsWith(year);
        }
    }
}
