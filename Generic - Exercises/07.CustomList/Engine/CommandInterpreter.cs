using System;
using System.Collections.Generic;
using System.Text;

public class CommandInterpreter
{
    private CustomList<string> customList;

    public CommandInterpreter(CustomList<string> customList)
    {
        this.customList = customList;
    }

    public void ReadCommands()
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] tokens = input.Split();

            string result = string.Empty;
            string element = string.Empty;
            int index = 0;

            string command = tokens[0];

            switch (command)
            {
                case "Add":
                    element = tokens[1];
                    this.customList.Add(element);
                    break;
                case "Remove":
                    index = int.Parse(tokens[1]);
                    result = this.customList.Remove(index);
                    break;
                case "Contains":
                    element = tokens[1];
                    bool isContains = this.customList.Contains(element);
                    Console.WriteLine(isContains);
                    break;
                case "Swap":
                    int firstIndex = int.Parse(tokens[1]);
                    int secondIndex = int.Parse(tokens[2]);
                    this.customList.Swap(firstIndex, secondIndex);
                    break;
                case "Greater":
                    element = tokens[1];
                    int counter = this.customList.CountGreaterThan(element);
                    Console.WriteLine(counter);
                    break;
                case "Max":
                    result = this.customList.Max();
                    Console.WriteLine(result);
                    break;
                case "Min":
                    result = this.customList.Min();
                    Console.WriteLine(result);
                    break;
                case "Sort":
                    this.customList.Sort();
                    break;
                case "Print":
                    Print();
                    break;
                default:
                    throw new ArgumentException("Invalid Command");
            }

            input = Console.ReadLine();
        }
    }

    private void Print()
    {
        foreach (var item in this.customList)
        {
            Console.WriteLine(item);
        }
    }
}

