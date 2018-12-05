using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
 
        private Dummy dummy;
        [SetUp]
        public void SetUp()
        {
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void TestIfWeaponLosesDurabilityAttack()
        {
            Axe axe = new Axe(10, 10);

            axe.Attack(dummy);

            var expected = 9;
            var actual = axe.DurabilityPoints;

            Assert.AreEqual(expected, actual, "Axe does not lose durability after atack");

        }

        [TestCase(10,0)]
        [TestCase(2, -0)]
        public void TestAttackingWithBrokenWeapon(int attackPoints, int durability)
        {
            Axe axe = new Axe(attackPoints,durability);

            // axe.Attack(dummy);

             Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.Throws(typeof(InvalidOperationException), () => axe.Attack(dummy));
            Assert.That(() => axe.Attack(dummy), 
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
