namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //read the members count
            int membersCount = int.Parse(Console.ReadLine());

            Family myFamily = new Family();

            //read the info for all members
            for (int i = 0; i < membersCount; i++)
            {
                string[] memberInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = memberInfo[0];
                int age = int.Parse(memberInfo[1]);

                //creat a new member
                Person member = new Person(name, age);

                //add the member to the family
                myFamily.AddMember(member);
            }

            //define oldest person
            Person oldestPerson = myFamily.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}