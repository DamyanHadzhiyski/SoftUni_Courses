using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        //field with the family memebers
        List<Person> familyMembers = new List<Person>();

        //methods
        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            int oldestAge = int.MinValue;
            Person oldestMember = new Person();

            foreach (var person in familyMembers)
            {
                if (person.Age > oldestAge) 
                {
                    oldestMember = person;
                    oldestAge = person.Age;
                }
            }

            return oldestMember;
        }

    }
}
