namespace DefiningClasses
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			Person person1 = new Person("Peter", 20);

			Person person2 = new Person();

			person2.Name = "George";
			person2.Age = 18;

			Person person3 = new Person("Jose", 43);
		}
	}

	public class Person
	{
		private string name;
		private int age;

		public Person()
		{

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