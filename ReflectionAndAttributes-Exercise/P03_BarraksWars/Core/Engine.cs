namespace _03BarracksFactory.Core
{
    using System;
    using System.Reflection;
    using System.Linq;
    using Contracts;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;


        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    IExecutable executable =this.commandInterpreter.InterpretCommand(data, commandName);
                    string result = executable.Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
