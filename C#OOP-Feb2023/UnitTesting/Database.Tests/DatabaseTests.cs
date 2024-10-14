namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
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
            Database database = new Database(2, 6, 8);
            int[] testArray = database.Fetch();

            Assert.AreEqual(2, testArray[0]);
            Assert.AreEqual(6, testArray[1]);
            Assert.AreEqual(8, testArray[2]);
            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void TestAddMethodThrowWhenMorehen16ElementsAndDoesNotAddElement()
        {
            Database database = new Database(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(3));
            Assert.AreEqual(exception.Message, "Array's capacity must be exactly 16 integers!");
            Assert.AreEqual(16, database.Count);
        }

        [Test]
        public void TestAddMethodIsAddingElement()
        {
            Database database = new Database( 5, 6, 7, 14, 15, 16);
            database.Add(3);
            int[] testArray = database.Fetch();

            Assert.AreEqual(3, testArray[6]);
            Assert.AreEqual(7, database.Count);
        }

        [Test]
        public void TestThatFetchMethodIsReturningTheCorrectArray()
        {
            Database database = new Database(5, 6, 7, 14, 15, 16);
            int[] testArray = database.Fetch();

            Assert.AreEqual(5, testArray[0]);
            Assert.AreEqual(6, testArray[1]);
            Assert.AreEqual(7, testArray[2]);
            Assert.AreEqual(14, testArray[3]);
            Assert.AreEqual(15, testArray[4]);
            Assert.AreEqual(16, testArray[5]);
        }

        [Test]
        public void TestThatcountPropertyIsReturningTheCorrectNumberOfElements()
        {
            Database database = new Database(5, 6, 7, 14, 15, 16);

            Assert.AreEqual(6, database.Count);
        }

        [Test]
        public void TestRemoveMethodThrowWhenThereAreNoElements()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Remove());
            Assert.AreEqual(exception.Message, "The collection is empty!");
        }

        [Test]
        public void TestRemoveMethodRemovesLastElement()
        {
            Database database = new Database(5, 6, 7, 14, 15, 16);
            database.Remove();
            int[] testArray = database.Fetch();

            Assert.AreEqual(15, testArray[testArray.Length-1]);
        }
    }
}
