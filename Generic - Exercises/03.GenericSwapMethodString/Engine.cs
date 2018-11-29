using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    public void SwapStrings()
    {
        var numberOfStrings = int.Parse(Console.ReadLine());
        List<string> items = new List<string>();
        
        for (int i = 0; i < numberOfStrings; i++)
        {
            string input = Console.ReadLine();
            items.Add(input);
        }

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int firstIndex = indexes[0];
        int secondIndex = indexes[1];

        string currentFirst = items[firstIndex];
        string currentSecond = items[secondIndex];

        items[secondIndex] = currentFirst;
        items[firstIndex] = currentSecond;

        for (int i = 0; i < items.Count; i++)
        {
            Box<string> box = new Box<string>(items[i]);
            Console.WriteLine(box);
        }
    }
}

