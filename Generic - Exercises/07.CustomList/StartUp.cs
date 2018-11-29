using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        CustomList<string> customList = new CustomList<string>();
        CommandInterpreter commandInterpreter = new CommandInterpreter(customList);
        commandInterpreter.ReadCommands();
    }
}

