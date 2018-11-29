using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();

        string fullName = $"{input[0]} {input[1]}";
        string address = input[2];
        string town = input[3];

        Console.WriteLine(new Threeuple<string, string, string>(fullName, address, town));

        input = Console.ReadLine().Split();

        string name = input[0];
        int liters = int.Parse(input[1]);
        bool drunkOrNot = input[2] == "drunk";

        Console.WriteLine(new Threeuple<string, int, bool>(name, liters, drunkOrNot));
        
        input = Console.ReadLine().Split();

        string personName = input[0];
        double balance = double.Parse(input[1]);
        string bankName = input[2];

        Console.WriteLine(new Threeuple<string, double, string>(personName, balance, bankName));
    }
}

