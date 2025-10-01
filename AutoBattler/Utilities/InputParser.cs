
using System;
using System.Globalization;

using static Extensions.ConsoleExtensions;

public class InputParser
{
    public static T GetInput<T>(string message, Predicate<T>? isValid = null) where T : IParsable<T>
    {
        while (true)
        {
            if (TryGetInput(message, out T result, isValid))
                return result!;
        }
    }

    public static bool TryGetInput<T>(string message, out T? result, Predicate<T>? predicate = null) where T : IParsable<T>
    {
        LogLine(message);
        Log("Ввод: ");

        string input = Console.ReadLine()!;

        if (T.TryParse(input, CultureInfo.InvariantCulture, out result) is false)
        {
            LogCritical($"\nНе удалось преобразовать ввод \"{input}\" в тип {typeof(T).Name}. Попробуйте ещё раз.");
            return false;
        }

        if(predicate is null || predicate.Invoke(result))
            return true;

        return false;
    }
}
