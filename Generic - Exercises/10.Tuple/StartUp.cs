using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        string[] personInfo = Console.ReadLine().Split();
        string[] nameBeer = Console.ReadLine().Split();
        string[] intDouble = Console.ReadLine().Split();

        string firstName = personInfo[0];
        string lastName = personInfo[1];
        string address = personInfo[2];

        string name = nameBeer[0];
        int liters = int.Parse(nameBeer[1]);

        int amount1 = int.Parse(intDouble[0]);
        double amount2 = double.Parse(intDouble[1]);

        Tuple<string, string> tuple1 = new Tuple<string, string>(firstName + " " + lastName, address);

        Tuple<string, int> tuple2 = new Tuple<string, int>(name, liters);

        Tuple<int, double> tuple3 = new Tuple<int, double>(amount1, amount2);

        Console.WriteLine(tuple1);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);
    }
}

