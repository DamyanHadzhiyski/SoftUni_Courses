using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //read the members count
            int personsCount = int.Parse(Console.ReadLine());

            //creat a list that will hold all persons info
            List<Person> personsList = new List<Person>();

            //get each persons info
            for (int i = 0; i < personsCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                //creat a new member
                Person member = new Person(name, age);

                personsList.Add(member);
            }

            personsList = personsList.OrderBy(p => p.Name).ToList();

            foreach (var person in personsList)
            {
                if (person.Age > 30)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            };
        }
    }
}