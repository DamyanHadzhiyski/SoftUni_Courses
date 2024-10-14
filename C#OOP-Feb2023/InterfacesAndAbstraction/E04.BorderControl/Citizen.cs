using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E04.BorderControl
{
    public class Citizen : IIdentifiable
    {
        private string id;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get => id; set => id = value; }

        public bool IsFake(string lastDigits)
        {
            return this.id.EndsWith(lastDigits);
        }
    }
}
