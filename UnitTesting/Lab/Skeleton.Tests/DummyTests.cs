using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {

        [Test]
        public void DummyLossesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(5);

            var actualResult = dummy.Health;
            var expected = 5;

            Assert.AreEqual(expected, actualResult);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAtacked()
        {

            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(20), "Dummy is dead.");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 123);

            var expected = 123;
            var actual = dummy.GiveExperience();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(10, 123);          

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead");
        }
    }
}
