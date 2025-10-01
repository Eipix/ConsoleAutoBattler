using System;
using System.Threading;

namespace Extensions;

public static class ConsoleExtensions
{
    public static void LogLine(object? value, ConsoleColor color = ConsoleColor.White, int delay = 0)
    {
        var defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(value);
        Console.ForegroundColor = defaultColor;
        Thread.Sleep(delay);
    }

    public static void Log(object? value, ConsoleColor color = ConsoleColor.White, int delay = 0)
    {
        var defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(value);
        Console.ForegroundColor = defaultColor;
        Thread.Sleep(delay);
    }

    public static void LogCritical(object? value, int delay = 1500)
    {
        LogLine(value, ConsoleColor.Red, delay);
        Console.Clear();
    }
}
