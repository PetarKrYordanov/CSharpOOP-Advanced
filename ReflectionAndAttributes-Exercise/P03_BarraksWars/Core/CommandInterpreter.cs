namespace _03BarracksFactory.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using _03BarracksFactory.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public const string prefix = "Command";
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unit)
        {
            this.repository = repository;
            this.unitFactory = unit;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string inputCommand = char.ToUpper(commandName[0]) + commandName.Substring(1) + prefix;
            Assembly asm = Assembly.GetExecutingAssembly();
            var types = asm.GetTypes();
            Type type = Type.GetType("_03BarracksFactory.Core.Commands." + inputCommand, true, true);
            

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            IExecutable executable = (IExecutable)Activator.CreateInstance(type, new[] { data });
            this.InjectDependancies(executable);

            return executable;
        }

        private void InjectDependancies(IExecutable command)
        {
            Type injectionType = typeof(InjectAttribute);


            IEnumerable<FieldInfo> fieldsForInjection = command.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(f => f.GetCustomAttributes().Any(a => a.GetType() == injectionType)).ToList();

            IEnumerable<FieldInfo> interpreterFields = this.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo fieldForInjection in fieldsForInjection)
            {
                fieldForInjection.SetValue(command, interpreterFields
                    .First(f => f.FieldType == fieldForInjection.FieldType)
                    .GetValue(this));
            }
        }
    }
}
