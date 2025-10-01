
using System;

using static GameConstants;
using static Extensions.ConsoleExtensions;

public class GameSessionController(Character character, CharacterSelector selector, Counter currentLevel)
{
    private readonly Character _character = character;
    private readonly CharacterSelector _selector = selector;
    private readonly Counter _currentLevel = currentLevel;

    public bool IsActive { get; private set; } = true;

    public bool TryEndingGame()
    {
        if (_character.IsDead)
        {
            DeclareDefeat();
            return true;
        }
        else if (_currentLevel >= MaxLevel)
        {
            DeclareVictory();
            return true;
        }

        return false;
    }

    private void DeclareDefeat()
    {
        string input = PlayerPrompts.GetYesOrNo("Вы проиграли! Желаете продолжить снова?");

        if (input is Yes)
            Restart();
        else
            Exit();
    }

    private void Restart()
    {
        _currentLevel.Reset();
        _character.Reset();
        Console.Clear();
        _selector.InitOrUpgrade(_character);
    }

    private void Exit()
    {
        LogLine("\nИгра завершена", delay: Middle);
        Console.Clear();
        IsActive = false;
    }

    private void DeclareVictory()
    {
        LogLine("Вы прошли игру!", Positive, Slow);
        IsActive = false;
    }
}
