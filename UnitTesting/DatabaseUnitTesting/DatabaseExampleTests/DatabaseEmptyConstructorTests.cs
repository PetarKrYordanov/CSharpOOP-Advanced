using System;
using System.Linq;
using System.Reflection;
using DatabaseExample;
using NUnit.Framework; 

namespace DatabaseExampleTests
{
    [TestFixture]
    public class DatabaseEmptyConstructorTests
    {
        private const int InitialCapacity = 16;
        private Type dbType;
        private Database database;

        [SetUp]
        public void TestInit()
        {
            this.dbType = typeof(Database);
            this.database = new Database();
        }

        [Test]
        public void TestEmptyConstructorData()
        {
          
            var data = dbType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(e => e.Name == "data")
                .GetValue(database);
       
            var actualLength =((int[]) data).Length;
            var expectedLength = InitialCapacity;

            Assert.That(actualLength, Is.EqualTo(expectedLength));
        }

        [Test]
        public void TestEmptyConstructorIndex()
        {
            var actualIndex = (int)dbType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(e => e.Name == "index")
                .GetValue(database);

            var expectedIndex = -1;

            Assert.That(()=>actualIndex,Is.EqualTo(expectedIndex));
        }

        [Test]
        public void TestEmptyConstructorShouldReturnNoElements()
        {
            var fetchResult = database.Fetch();
            var expected = new int[0];

            Assert.AreEqual(expected, fetchResult);
        }

        [Test]
        public void ShouldThrowExceptionIfDataIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(()=> database.Remove(),
                "Database is empty.You cannot remove elements");
        }

        [Test]
        public void ShouldThrowAnErrorIfAddMoreThanCapacity()
        {
            for (int i = 0; i < InitialCapacity; i++)
            {
                database.Add(1);
            }

            var actualResult = string.Join("", database.Fetch());
            var expectedResult = new string('1', 16);

            var actualIndex = dbType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(e => e.Name == "index")
                .GetValue(database);

            var expectedIndex = InitialCapacity - 1;

            Assert.AreEqual(actualIndex, expectedIndex);

            Assert.AreEqual(expectedResult, actualResult);

            Assert.Throws<InvalidOperationException>(() => database.Add(1),
                "Database is full. You cannot add any elements");
        }
    }
}
