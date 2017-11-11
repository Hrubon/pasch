using System;


public class ConsoleOutput : Output
{
    public override void Write(string message, params object[] args)
    {
        Console.WriteLine(message, args);
    }
}