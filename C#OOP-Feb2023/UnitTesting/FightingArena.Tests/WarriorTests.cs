namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [TearDown]
        public void TearDown()
        {
            warrior = null;
        }

        [Test]
        public void TestConstructorForFillingDataCorrectly()
        {
            warrior = new Warrior("Ivan", 20, 40);

            Assert.That(warrior.Name, Is.EqualTo("Ivan"));
            Assert.That(warrior.Damage, Is.EqualTo(20));
            Assert.That(warrior.HP, Is.EqualTo(40));
        }

        [Test]
        public void TestNamePropertyReturnsCorrectName()
        {
            warrior = new Warrior("Ivan", 20, 40);

            Assert.That(warrior.Name, Is.EqualTo("Ivan"));
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void TestNamePropertyThrowsWhenNullEmptyOrWhiteSpace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior(name, 20, 40));
            Assert.That(exception.Message, Is.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void TestDamagePropertyReturnsCorrectDamage()
        {
            warrior = new Warrior("Ivan", 20, 40);

            Assert.That(warrior.Damage, Is.EqualTo(20));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void TestDamagePropertyThrowsWhenZeroOrNegative(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Ivan", damage, 40));
            Assert.That(exception.Message, Is.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void TestHPPropertyReturnsCorrectHP()
        {
            warrior = new Warrior("Ivan", 20, 40);

            Assert.That(warrior.HP, Is.EqualTo(40));
        }

        [Test]
        public void TestHPPropertyThrowsWhenNegative()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Ivan", 20, -1));
            Assert.That(exception.Message, Is.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void TestAttackMethodTakesTheCorrectHPFromAttackedWarrior()
        {
            Warrior attacker = new Warrior("Ivan", 15, 40);
            Warrior defender = new Warrior("Andrey", 20, 40);

            attacker.Attack(defender);

            Assert.That(defender.HP, Is.EqualTo(25));
        }

        [Test]
        public void TestAttackMethodTakesTheCorrectHPFromAttacker()
        {
            Warrior attacker = new Warrior("Ivan", 15, 40);
            Warrior defender = new Warrior("Andrey", 20, 40);

            attacker.Attack(defender);

            Assert.That(attacker.HP, Is.EqualTo(20));
        }

        [Test]
        public void TestAttackMethodReturnsZeroWhenAttackerDamageIsMoreThanDefenderHP()
        {
            Warrior attacker = new Warrior("Ivan", 45, 40);
            Warrior defender = new Warrior("Andrey", 20, 40);

            attacker.Attack(defender);

            Assert.That(defender.HP, Is.EqualTo(0));
        }

        [Test]
        [TestCase(29)]
        [TestCase(30)]
        public void TestAttackMethodThrowsWhenAttackerHPLessThanMinHP(int attckerHP)
        {
            Warrior attacker = new Warrior("Ivan", 15, attckerHP);
            Warrior defender = new Warrior("Andrey", 20, 40);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.That(exception.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        [TestCase(29)]
        [TestCase(30)]
        public void TestAttackMethodThrowsWhenDefenderHPLessThanMinHP(int defenderHP)
        {
            Warrior attacker = new Warrior("Ivan", 15, 40);
            Warrior defender = new Warrior("Andrey", 20, defenderHP);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.That(exception.Message, Is.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void TestAttackMethodThrowsWhenAttackerHPLessThanDefenderDamage()
        {
            Warrior attacker = new Warrior("Ivan", 40, 40);
            Warrior defender = new Warrior("Andrey", 50, 40);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.That(exception.Message, Is.EqualTo("You are trying to attack too strong enemy"));
        }
    }
}