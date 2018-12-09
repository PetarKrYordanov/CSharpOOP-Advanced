 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
          var command = Console.ReadLine();

            while (command != "HARVEST")
            {
                Type myType = typeof(HarvestingFields);

                var fields = myType.GetFields((BindingFlags) 62);
                switch (command)
                {
                    case "public":
                        Console.WriteLine(string
                            .Join(Environment.NewLine, fields.Where(f=>f.IsPublic).Select(e => $"public {e.FieldType.Name} {e.Name}")));
                        break;
                    case "private":
                        Console.WriteLine(string
                           .Join(Environment.NewLine, fields.Where(f => f.IsPrivate).Select(e => $"private {e.FieldType.Name} {e.Name}")));
                        break;
                    case "protected":

                        fields = fields.Where(e => e.IsFamily).ToArray();
                        Console.WriteLine(string
                           .Join(Environment.NewLine, fields.Select(e=> $"protected {e.FieldType.Name} {e.Name}")));
                        break;
                    case "all":
                        foreach (var item in fields)
                        {
                            var modifier = (item.Attributes.ToString() == "Family") ? "protected" : item.Attributes.ToString().ToLower();
                            Console.WriteLine($"{modifier} {item.FieldType.Name} {item.Name}");
                        }                        
                        break;
                    default:
                        Console.WriteLine(string.Join<string>(Environment.NewLine, fields.Select(e=> e.Attributes +" "+ e)));
                        break;
                }
               
                command = Console.ReadLine();
            }
        }
    }
}
