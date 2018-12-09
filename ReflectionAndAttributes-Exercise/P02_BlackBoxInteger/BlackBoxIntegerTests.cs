namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            Type type = typeof(BlackBoxInteger);
                      
            var box = Activator.CreateInstance(type, true);
            var innerValue = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

            while (input != "END")
            {
                var args = input.Split("_");
                var command = args[0];
                var number = int.Parse(args[1]);

                var method = type.GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(box, new object[] { number });

                Console.WriteLine(innerValue.GetValue(box));

                input = Console.ReadLine();
            }
        }
    }
}
