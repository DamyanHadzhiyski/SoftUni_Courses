namespace E05.ComparingObjects
{
	public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) == 0 
                && Age.CompareTo(other.Age) == 0 
                && Town.CompareTo(other.Town) == 0)
            {
                return 0;
            }

            return 1;
        }
    }
}
