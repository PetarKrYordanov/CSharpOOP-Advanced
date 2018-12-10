using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class VehicleTests
    {
        private Type vehicle;

        [SetUp]
        public void SetUp()
        {
            this.vehicle = this.GetType("Vehicle");
        }

        [Test]
        public void ValidateAllVehicleTypes()
        {
            var expectedTypes = new[]
            {
                "Semi",
                "Truck",
                "Van",
                "Vehicle"
            };

            foreach (var type in expectedTypes)
            {
                var expectedType = GetType(type);

                Assert.That(expectedType, Is.Not.Null, $"{type} does not exist!");
            }
        }

        [Test]
        public void ValidateConstructorAndParameters()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;

            var constructor = this.vehicle.GetConstructors(flags).FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, "Constructor cannot be null!");

            var constructorParams = constructor.GetParameters();

            Assert.That(constructorParams[0].ParameterType, Is.EqualTo(typeof(int)));
        }

        [Test]
        public void ValidateChildClasses()
        {
            var childClasses = new[]
            {
                GetType("Semi"),
                GetType("Truck"),
                GetType("Van")
            };

            foreach (var item in childClasses)
            {
                Assert.That(item.BaseType, Is.EqualTo(this.vehicle),
                    $"{item} does not inherit {vehicle}");
            }
        }

        [Test]
        public void ValidateProperties()
        {
            var actualProperties = this.vehicle.GetProperties();

            var expectedProperties = new Dictionary<string, Type>
            {
                { "Capacity", typeof(int) },
                {"Trunk", typeof(IReadOnlyCollection<Product>) },
                { "IsFull", typeof(bool) },
                { "IsEmpty", typeof(bool) }
            };

            foreach (var expectedType in expectedProperties)
            {
                var isValid = actualProperties.Any(x => x.Name == expectedType.Key
                && x.PropertyType == expectedType.Value);

              Assert.That(isValid, $"Property with name {expectedType.Key} is not valid");
            }
        }

        [Test]
        public void ValidateVehicleMethod()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(void), "LoadProduct", typeof(Product)),
                new Method(typeof(Product), "Unload")
            };

            foreach (var methodExpected in expectedMethods)
            {
                var currentMethod = this.vehicle.GetMethod(methodExpected.Name);

                Assert.That(currentMethod, Is.Not.Null, $"{methodExpected.Name} does not exists!");

                var returnType = currentMethod.ReturnParameter.ParameterType.FullName == methodExpected.ReturnType.FullName;
                Assert.That(returnType,
                    $"Metho with name {methodExpected.Name} return type is not valid expected {methodExpected.ReturnType.Name}");

                var expectedParams = methodExpected.InputParameters;
                var actualParams = currentMethod.GetParameters();

                for (int i = 0; i < expectedParams.Length; i++)
                {
                    var actualParam = actualParams[i].ParameterType;
                    var expectedParam = expectedParams[i];

                    Assert.AreEqual(expectedParam, actualParam);
                }
            }
        }

        [Test]
        public void ValidataVehicleIsAbstract()
        {
            Assert.That(vehicle.IsAbstract, "Vehicle class must be abstract");
        }

        [Test]
        public void ValidateVehicleFields()
        {
            var trunkField = this.vehicle.GetField("trunk", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(trunkField, Is.Not.Null, "Field with name trunk not found");

            var flag = trunkField.Attributes.HasFlag(FieldAttributes.InitOnly | FieldAttributes.Private);
            Assert.That(flag);
         //   trunkField.is
        }
        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParameters)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParameters = inputParameters;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputParameters { get; set; }
        }

        public Type GetType(string type)
        {
            var targetType = typeof(StartUp)
                    .Assembly
                    .GetTypes()
                    .FirstOrDefault(x => x.Name == type);

            return targetType;
        }
    }
}
