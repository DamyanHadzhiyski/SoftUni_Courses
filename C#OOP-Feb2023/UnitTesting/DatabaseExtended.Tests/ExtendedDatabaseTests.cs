namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUP()
        {
            database = new Database();
        }

        [TearDown]
        public void TearDown()
        {
            database = null;
        }

        [Test]
        public void TestConstructorForAddingArrayAndIncreasingCount()
        {
            Database database = new Database(new Person(3, "Gosho"), new Person(4, "Ivan"));
            Person testPerson1 = database.FindByUsername("Gosho");
            Person testPerson2 = database.FindByUsername("Ivan");

            Assert.That(testPerson1.UserName, Is.EqualTo("Gosho"));
            Assert.That(testPerson1.Id, Is.EqualTo(3));
            Assert.That(testPerson2.UserName, Is.EqualTo("Ivan"));
            Assert.That(testPerson2.Id, Is.EqualTo(4));
            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void TestConstructorThrowWhenMoreThen16ElementsAndDoesNotAddElement()
        {
            Person[] persons = CreatePersons(17);

            ArgumentException exception = Assert.Throws<ArgumentException>(() => database = new Database(persons));
            Assert.AreEqual(exception.Message, "Provided data length should be in range [0..16]!");
            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void TestAddMethodIsAddingElement()
        {
            database.Add(new Person(4, "Ivan"));
            Person addedPerson = database.FindByUsername("Ivan");

            Assert.That(addedPerson.UserName, Is.EqualTo("Ivan"));
            Assert.That(addedPerson.Id, Is.EqualTo(4));
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void TestAddMethodThrowWhenThereAreMoreThen16Elements()
        {
            Person[] persons = CreatePersons(16);
            database = new Database(persons);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(16, 16.ToString())));
            Assert.AreEqual(exception.Message, "Array's capacity must be exactly 16 integers!");
            Assert.That(database.Count, Is.EqualTo(16));
        }

        [Test]
        public void TestAddMethodThrowWhenTheUsernameExists()
        {
            database = new Database(new Person(3, "Ivan"));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(4, "Ivan")));
            Assert.AreEqual(exception.Message, "There is already user with this username!");
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestAddMethodThrowWhenTheIdExists()
        {
            database = new Database(new Person(3, "Ivan"));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(3, "Andrey")));
            Assert.AreEqual(exception.Message, "There is already user with this Id!");
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestFindByUsernameMethodThrowWhenTheUsernameIsNullOrEmpty(string nullOrEmpty)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(nullOrEmpty));
            Assert.AreEqual(exception.ParamName, "Username parameter is null!");
        }

        [Test]
        public void TestFindByUsernameMethodThrowWhenTheUsernameDoesNotExists()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Ivan"));
            Assert.AreEqual(exception.Message, "No user is present by this username!");
        }

        [Test]
        public void TestFindByUsernameMethodWhenUsernameExists()
        {
            database = new Database(new Person(3, "Ivan"));
            Person person = database.FindByUsername("Ivan");

            Assert.That(person.UserName, Is.EqualTo("Ivan"));
            Assert.That(person.Id, Is.EqualTo(3));
        }

        [Test]
        public void TestFindByIdMethodThrowWhenTheIdIsNegative()
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-2));
            Assert.AreEqual(exception.ParamName, "Id should be a positive number!");
        }

        [Test]
        public void TestFindByIdMethodThrowWhenTheIdDoesNotExists()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.FindById(3));
            Assert.AreEqual(exception.Message, "No user is present by this ID!");
        }

        [Test]
        public void TestFindByIdMethodWhenIdExists()
        {
            database = new Database(new Person(3, "Ivan"));
            Person person = database.FindById(3);

            Assert.That(person.UserName, Is.EqualTo("Ivan"));
            Assert.That(person.Id, Is.EqualTo(3));
        }

        [Test]
        public void TestThatcountPropertyIsReturningTheCorrectNumberOfElements()
        {
            Person[] persons = CreatePersons(15);
            Database database = new Database(persons);

            Assert.AreEqual(15, database.Count);
        }

        [Test]
        public void TestRemoveMethodThrowWhenThereAreNoElements()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Remove());
            Assert.AreEqual(exception.Message, "Operation is not valid due to the current state of the object.");
        }

        [Test]
        public void TestRemoveMethodRemovesLastElement()
        {
            Database database = new Database(new Person(3, "Gosho"), new Person(4, "Ivan"));
            
            database.Remove();

            Person lastPersonAfterRemove = database.FindByUsername("Gosho");

            Assert.That(lastPersonAfterRemove.UserName, Is.EqualTo("Gosho"));
            Assert.That(lastPersonAfterRemove.Id, Is.EqualTo(3));
            Assert.AreEqual(1, database.Count);
        }
        
        private Person[] CreatePersons(int count)
        {
            Person[] result = new Person[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = new Person(i, i.ToString());
            }

            return result;
        }
    }
}