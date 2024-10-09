namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person1 = new Person();

            Person person2 = new Person(32);

            Person person3 = new Person("Jose", 43);
        }
    }

    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age) : this()
        {
            Age = age;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

    }
}