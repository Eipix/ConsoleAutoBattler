
using Extensions;
using System.Collections.Generic;
using System.Reflection;

using static GameConstants;
using static Extensions.ConsoleExtensions;

public class CharacterSelector
{
    private readonly IReadOnlyList<Class> _classes;

    public CharacterSelector(Assembly assembly)
    {
        _classes = ReflectionExtensions.GetInstancesOfType<Class>(assembly);
    }

    public void InitOrUpgrade(Character character, string message = "Выберите класс персонажа")
    {
        string text = $"\n{message}: \n{_classes.GetNumerated()}";
        int choice = PlayerPrompts.GetClassNumber(text, _classes.Count);

        var characterClass = _classes[choice - 1];
        character.InitOrUpgradeClass(characterClass);

        LogLine($"\nВыбран класс - {characterClass.Name}\n", Info, Fast);
        LogLine($"{character}\n", Info, Middle);
    }
}
