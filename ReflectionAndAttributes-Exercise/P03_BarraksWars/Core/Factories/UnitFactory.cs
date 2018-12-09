namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var fullType = "_03BarracksFactory.Models.Units." + unitType;


            Type type = Type.GetType(fullType);

            IUnit instance = (IUnit) Activator.CreateInstance(type);

            return instance;
        }
    }
}
