namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [TearDown]
        public void TearDown()
        {
            arena = null;
        }

        [Test]
        public void TestEnrollMethodEnrollsNewWarrior()
        {
            Warrior warrior = new Warrior("Ivan", 30, 40);

            arena.Enroll(warrior);

            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestEnrollMethodThrowsWhenWarriorAlreadyenrolled()
        {
            Warrior warrior1 = new Warrior("Ivan", 30, 40);
            arena.Enroll(warrior1);

            Warrior warrior2 = new Warrior("Ivan", 10, 40);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior2));
            Assert.That(exception.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestFightMethodCorrectlyPerformsTheAttack()
        {
            Warrior attacker = new Warrior("Ivan", 15, 40);
            arena.Enroll(attacker);
            Warrior defender = new Warrior("Gosho", 20, 40);
            arena.Enroll(defender);

            string attackerName = "Ivan";
            string defenderName = "Gosho";

            arena.Fight(attackerName, defenderName);

            Assert.That(attacker.HP, Is.EqualTo(20));
            Assert.That(defender.HP, Is.EqualTo(25));
        }

        [Test]
        public void TestFightMethodThrowsWhenAttackerNameDoesNotExists()
        {
            Warrior warrior1 = new Warrior("Ivan", 30, 40);
            arena.Enroll(warrior1);
            Warrior warrior2 = new Warrior("Gosho", 30, 40);
            arena.Enroll(warrior2);

            string attackerName = "Ivana";
            string defenderName = "Gosho";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
            Assert.That(exception.Message, Is.EqualTo($"There is no fighter with name {attackerName} enrolled for the fights!"));
        }

        [Test]
        public void TestFightMethodThrowsWhenDefenderNameDoesNotExists()
        {
            Warrior warrior1 = new Warrior("Ivan", 30, 40);
            arena.Enroll(warrior1);
            Warrior warrior2 = new Warrior("Gosho", 30, 40);
            arena.Enroll(warrior2);

            string attackerName = "Ivan";
            string defenderName = "Ivana";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
            Assert.That(exception.Message, Is.EqualTo($"There is no fighter with name {defenderName} enrolled for the fights!"));
        }

        [Test]
        public void TestFightMethodThrowsAndReturnsDefenderNameWhenAttackerAndDefenderNamesDoesNotExists()
        {
            Warrior warrior1 = new Warrior("Ivan", 30, 40);
            arena.Enroll(warrior1);
            Warrior warrior2 = new Warrior("Gosho", 30, 40);
            arena.Enroll(warrior2);

            string attackerName = "Gergana";
            string defenderName = "Ivana";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
            Assert.That(exception.Message, Is.EqualTo($"There is no fighter with name {defenderName} enrolled for the fights!"));
        }
    }
}
