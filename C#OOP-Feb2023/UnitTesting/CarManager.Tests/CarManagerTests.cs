namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Mazda", "6", 5, 64);
        }

        [TearDown]
        public void TearDown()
        {
            car = null;
        }


        [Test]
        public void TestConstructorForPassingCorrectData()
        {
            car = new Car("Mazda", "6", 6.1, 64);

            Assert.That(car.Make, Is.EqualTo("Mazda"));
            Assert.That(car.Model, Is.EqualTo("6"));
            Assert.That(car.FuelConsumption, Is.EqualTo(6.1));
            Assert.That(car.FuelCapacity, Is.EqualTo(64));
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void TestMakePropertyReturnsCorrectValue()
        {
            Assert.That(car.Make, Is.EqualTo("Mazda"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestMakePropertyThrowsWhenNullOrEmpty(string make)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new Car(make, "6", 6.1, 64));
            Assert.That(exception.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void TestModelPropertyReturnsCorrectValue()
        {
            Assert.That(car.Model, Is.EqualTo("6"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestModelPropertyThrowsWhenNullOrEmpty(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new Car("Mazda", model, 6.1, 64));
            Assert.That(exception.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void TestFuelConsumptionPropertyReturnsCorrectValue()
        {
            Assert.That(car.FuelConsumption, Is.EqualTo(5));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestFuelConsumptionPropertyThrowsWhenZeroOrNegative(double fuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new Car("Mazda", "6", fuelConsumption, 64));
            Assert.That(exception.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void TestFuelAmountPropertyReturnsCorrectValue()
        {
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void TestFuelCapacityPropertyReturnsCorrectValue()
        {
            Assert.That(car.FuelCapacity, Is.EqualTo(64));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestFuelCapacityPropertyThrowsWhenZeroOrNegative(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new Car("Mazda", "6", 6.1, fuelCapacity));
            Assert.That(exception.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestRefuelMethodThrowsWhenZeroOrNegative(double refuelAmount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car.Refuel(refuelAmount));
            Assert.That(exception.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void TestRefuelMethodSetMaxCapacityIfAmountHigher()
        {
            car.Refuel(90);

            Assert.That(car.FuelAmount, Is.EqualTo(64));
        }

        [Test]
        public void TestRefuelMethodCalculatesCorrectly()
        {
            car.Refuel(34);

            Assert.That(car.FuelAmount, Is.EqualTo(34));
        }

        [Test]
        public void TestDriveMethodThrowsWhenNotEnoughFuel()
        {
            double distance = 100;
            car.Refuel(4.9);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
            Assert.That(exception.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void TestDriveMethodReturnCorrectFuelLeftAfterDrive()
        {
            double distance = 100;
            car.Refuel(10);

            car.Drive(100);

            Assert.That(car.FuelAmount, Is.EqualTo(5));
        }
    }
}