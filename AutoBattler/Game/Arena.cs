using System;
using System.Collections.Generic;
using System.Reflection;
using Extensions;

using static GameConstants;
using static Extensions.ConsoleExtensions;

public class Arena
{
    private readonly IReadOnlyList<Enemy> _enemies;

    private readonly Character _character = new();
    private readonly Counter _level = new();
    private readonly Counter _turn = new();
    private readonly CharacterSelector _characterSelector = new();
    private readonly GameSessionController _sessionController;

    public Arena()
    {
        var assembly = Assembly.GetExecutingAssembly();
        _enemies = ReflectionExtensions.GetInstancesOfType<Enemy>(assembly);

        _sessionController = new(_character, _characterSelector, _level);
    }

    public void Start()
    {
        _characterSelector.InitOrUpgrade(_character);
        Console.Clear();

        while (_sessionController.IsActive)
        {
            var enemy = GetRandomEnemy();

            _level.Increment();

            FightEnemy(enemy);

            if (_sessionController.TryEndingGame())
                continue;

            LogLine("Вы победили!\n", Positive, Fast);

            OfferReward(enemy.Reward);
            UpgradeOrRecoveryCharacter();

            Console.Clear();
        }
    }

    private Enemy GetRandomEnemy()
    {
        var enemy = _enemies[Random.Shared.Next(0, _enemies.Count)];
        enemy.Recovery();
        return enemy;
    }

    private void FightEnemy(Enemy enemy)
    {
        LogLine($"{_character}\n", Info);
        LogLine($"Ваш текущий противник - {enemy}\n", enemy.Color, Fast);

        var (first, second) = SetupBattleOrder(enemy);
        while (enemy.IsAlive && _character.IsAlive)
        {
            _turn.Increment();

            Attack(first, second);
            Attack(second, first);
        }
        _turn.Reset();
    }

    private (Entity first, Entity second) SetupBattleOrder(Enemy enemy)
    {
        return _character.Agility >= enemy.Agility
            ? (_character, enemy)
            : (enemy, _character);
    }

    private void Attack(Entity attacker, Entity target)
    {
        if (attacker.IsDead || target.IsDead)
            return;

        var context = new BattleContext(attacker.DamageContext, target.DamageContext, _turn);

        if(target.TryTakeDamage(context, out DamageResults results))
        {
            LogLine($"{attacker.Name} наносит {target.Name} - {results.Processed} урона! (Бонус атакующего: {results.AttackerBonus}; Бонус цели: {results.TargetBonus})\nОставшееся HP {target.Name}: {target.Health}\n", attacker.ApplyDamageColor, Slow);        
        }
        else
        {
            LogLine($"{attacker.Name} промахнулся!\n", Info, Slow);
        }
    }

    private void OfferReward(Weapon reward)
    {
        string message = $"Вам выпало оружие {reward}.\n\nВаше текущее оружие {_character.Weapon}.\n\nЖелаете заменить?";
        string? input = PlayerPrompts.GetYesOrNo(message);

        if (input is Yes)
        {
            _character.EquipWeapon(reward);
            LogLine($"\n{reward.Name} успешно экипировано!\n", Positive, delay: Fast);
        }
    }

    private void UpgradeOrRecoveryCharacter()
    {
        if (_character.SummaryLevel < MaxClassLevel)
            _characterSelector.InitOrUpgrade(_character, "Выберите класс который хотите освоить или улучшить имеющие");
        else
            _character.Recovery();
    }
}
