using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    public void BoxOfString()
    {
        var numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            string input = Console.ReadLine();
            Box<string> box = new Box<string>(input);
            Console.WriteLine(box);
        }
    }
}

