using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using StorageMaster;
using System.Collections.Generic;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Factories;
using StorageMaster.Entities.Vehicles;

namespace StorageMester.BusinessLogic.Tests
{
    [TestFixture]
    public class StorageMasterTests
    {
        private Type storageMaster;
        private StorageMaster.Core.StorageMaster instance;
        private FieldInfo[] fields;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = GetType("StorageMaster");
            this.instance =(StorageMaster.Core.StorageMaster) 
                Activator.CreateInstance(this.storageMaster);            
        }

        [Test]
        public void ValidatePrivateFields()
        {
            var actualFields = this.storageMaster.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var expectedFields = new Dictionary<string, Type>
            {
                { "storageRegistry", typeof(Dictionary<string, Storage>) },
                { "productsPool", typeof(Dictionary<string, Stack<Product>>) },
                { "productFactory", typeof(ProductFactory) },
                { "storageFactory", typeof(StorageFactory) },
                { "currentVehicle", typeof(Vehicle) }
            };

            var count = 0;
            foreach (var expectedField in expectedFields)
            {
                var actualField = actualFields.FirstOrDefault(e => e.Name == expectedField.Key);

                Assert.That(actualField, Is.Not.Null,
                    $"Field with name {expectedField.Key} does not exists!");

                var fieldType = actualField.FieldType;
                Assert.That(fieldType, Is.EqualTo(expectedField.Value));

                //Check is readonly first four fields
                count++;
                if (count < 5)
                {
                    bool isReadOnly = actualField.Attributes.HasFlag(FieldAttributes.InitOnly);
                    Assert.That(isReadOnly, $"Field {expectedField.Key} must be readonly");
                }
            }
        }

        [Test]
        public void CheckAllMethodsSignature()
        {
            var expectedMethods = new Method[]
            {
                new Method(typeof(string), "AddProduct", typeof(string),typeof(double)),
                new Method(typeof(string), "RegisterStorage", typeof(string), typeof(string)),
                new Method(typeof(string), "SelectVehicle", typeof(string), typeof(int)),
                new Method(typeof(string), "LoadVehicle", typeof(IEnumerable<string>)),
                new Method(typeof(string), "SendVehicleTo", typeof(string), typeof(int), typeof(string)),
                new Method(typeof(string), "UnloadVehicle", typeof(string), typeof(int)),
                new Method(typeof(string), "GetStorageStatus", typeof(string)),
                new Method(typeof(string), "GetSummary")
            };

            foreach (var expectedMethod in expectedMethods)
            {
                var actualMethod = this.storageMaster.GetMethod(expectedMethod.Name);
                Assert.That(actualMethod, Is.Not.Null,
                    $"Method with name {expectedMethod.Name} does not exists!");

                var returnType = actualMethod.ReturnType;
                Assert.AreEqual(returnType, expectedMethod.ReturnType,
                   $"Method with name {expectedMethod.Name} must return {expectedMethod.ReturnType.Name}");

                var expectedParams = expectedMethod.InputParams;
                var actualParams = actualMethod.GetParameters();
                for (int i = 0; i < expectedParams.Length; i++)
                {
                    var actual = actualParams[i].ParameterType.Name;
                    var expected = expectedParams[i].Name;

                    Assert.AreEqual(expected, actual);
                }
            }
        }
        [TestCase("Gpu",1)]
        [TestCase("HardDrive",1)]
        [TestCase("Ram",1)]
        [TestCase("SolidStateDrive",1)]
        public void ValidateAddProductMethod(string type, double price)
        {
            var method = this.storageMaster.GetMethod("AddProduct");
          var actualStringResult=  method.Invoke(instance, new object[] { type, price });
            var expectedStringResutl = $"Added {type} to pool";
            Assert.AreEqual(expectedStringResutl, actualStringResult);

            var productPoolField = (IDictionary<string, Stack<Product>>)storageMaster
                .GetField("productsPool", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);
            var count = productPoolField[type].Count;
            Assert.AreEqual(1, count,$"Count in productsPool[{type}] must be equal one");
        }

        [TestCase("Gpus",1)]
        [TestCase("Ram", -1)]
        [TestCase("Product", 1)]
        public void ManupulateAddProductWithError(string type, double price)
        {
            var method = this.storageMaster.GetMethod("AddProduct");
            Assert.Catch(() =>method.Invoke(instance, new object[] { type, price }),
                "Should throw an error!");
        }

        [TestCase("Warehouse", "Ivan")]
        [TestCase("DistributionCenter", "Gosho")]
        [TestCase("AutomatedWarehouse", "Pesho")]
        public void ValidateRegisterStorageMethod(string type, string name)
        {
            var method = this.storageMaster.GetMethod("RegisterStorage");
            var actualStringResult = method.Invoke(instance, new object[] { type, name});
            var expectedStringResutl = $"Registered {name}";
            Assert.AreEqual(expectedStringResutl, actualStringResult);

            var storageRegistryValue = (IDictionary<string, Storage>)storageMaster
                .GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);

            var storage = storageRegistryValue[name];
            Assert.That(storage, Is.Not.Null,$"Storage of type {type} does not exists");

            Assert.AreEqual(name, storage.Name);
        }

        [TestCase("Storage", "Ivan")]       
       [TestCase("DistributionsCenter", "23")]
        [TestCase("AutomatedWarehouses", "Pesho")]
        public void ManupulateRegisterStorageWithError(string type, string name)
        {
            var method = this.storageMaster.GetMethod("RegisterStorage");
            Assert.Catch(() => method.Invoke(instance, new object[] { type, name }),
                "Should throw an error!");
        }

        [TestCase("Gosho",1)]
        [TestCase("pesho",1)]
        [TestCase("Ivan",1)]
        public void ValidateSelectVehicleMethod(string storageName, int garageSlot)
        {

        }


        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParams)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParams = inputParams;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputParams { get; set; }

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
