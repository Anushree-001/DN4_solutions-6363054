// See https://aka.ms/new-console-template for more information

using System;

public class Logger
{
    private static Logger instance = new Logger();

    private Logger()
    {
        Console.WriteLine("Logger started");
    }

    public static Logger GetInstance()
    {
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger log = Logger.GetInstance();
        log.Log("First message");

        Logger anotherLog = Logger.GetInstance();
        anotherLog.Log("Second message");

        if (log == anotherLog)
        {
            Console.WriteLine("Both are Same logger");
        }
    }
}

