using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    public void SwapStrings()
    {
        var numberOfStrings = int.Parse(Console.ReadLine());
        List<int> items = new List<int>();
        
        for (int i = 0; i < numberOfStrings; i++)
        {
            int input = int.Parse(Console.ReadLine());
            items.Add(input);
        }

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int firstIndex = indexes[0];
        int secondIndex = indexes[1];

        int currentFirst = items[firstIndex];
        int currentSecond = items[secondIndex];

        items[secondIndex] = currentFirst;
        items[firstIndex] = currentSecond;

        for (int i = 0; i < items.Count; i++)
        {
            Box<int> box = new Box<int>(items[i]);
            Console.WriteLine(box);
        }
    }
}

