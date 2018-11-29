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

        List<double> items = new List<double>();
        
        for (int i = 0; i < numberOfStrings; i++)
        {
            double input = double.Parse(Console.ReadLine());
            items.Add(input);
        }

        double compareNum = double.Parse(Console.ReadLine());

        Box<double> box = new Box<double>(compareNum);

        for (int i = 0; i < items.Count; i++)
        {
            Box<double> currentBox = new Box<double>(items[i]);

            int result = box.CompareTo(currentBox);

            if (result == -1)
            {
                totalNums++;
            }
        }

        Console.WriteLine(totalNums);
    }
}

