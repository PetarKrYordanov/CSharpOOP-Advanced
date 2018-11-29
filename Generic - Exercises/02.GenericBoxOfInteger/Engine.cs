using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    public void BoxOfIntegers()
    {
        var numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            int input = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>(input);
            Console.WriteLine(box);
        }
    }
}

