using Extensions;

using static Extensions.ConsoleExtensions;
using static GameConstants;

public static class PlayerPrompts
{
    public static string GetYesOrNo(string message)
    {
        string prompt = $"{message} ({Yes}/{No})\n";
        string input = InputParser.GetInput<string>(prompt, IsValid);
        return input;

        static bool IsValid(string? input)
        {
            if (input is Yes or No)
                return true;

            LogCritical($"\nНеверный ввод. Введите \"{Yes}\" или \"{No}\".", Fast);
            return false;
        }
    }

    public static int GetClassNumber(string message, int maxClassCount)
    {
        int choice = InputParser.GetInput<int>(message, IsValid);
        return choice;

        bool IsValid(int choice)
        {
            if (choice.InRange(1, maxClassCount) is false)
            {
                LogCritical("\n Не существует персонажа под указанным номером!");
                return false;
            }

            return true;
        }
    }
}