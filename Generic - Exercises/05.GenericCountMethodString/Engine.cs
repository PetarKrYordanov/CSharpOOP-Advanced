using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    public void SwapStrings()
    {
        var numberOfStrings = int.Parse(Console.ReadLine());
        int totalNums = 0;

        List<string> items = new List<string>();
        
        for (int i = 0; i < numberOfStrings; i++)
        {
            string input = Console.ReadLine();
            items.Add(input);
        }

        string compareText = Console.ReadLine();

        Box<string> box = new Box<string>(compareText);

        for (int i = 0; i < items.Count; i++)
        {
            Box<string> currentBox = new Box<string>(items[i]);

            int result = box.CompareTo(currentBox);

            if (result == -1)
            {
                totalNums++;
            }
        }

        Console.WriteLine(totalNums);
    }
}

