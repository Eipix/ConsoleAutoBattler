
using System;
using System.Collections.Generic;
using System.Linq;

public abstract record Class(IBonus[] Bonuses, Weapon Weapon, int HealthPerLevel, string Name)
{
    public IEnumerable<IBonus> CurrentBonuses => Bonuses[..Level];
    public int Level { get; private set; } = 1;
    public string Status => $"{Name} {Level}";

    public void LevelUp()
    {
        Level++;

        if (Level > GameConstants.MaxClassLevel)
            throw new InvalidOperationException($"Уровень [{Level}] превышает максимальное число уровней [{GameConstants.MaxClassLevel}]!");
    }

    public void Reset() => Level = 1;

    public sealed override string ToString() => $"{Name} - Здоровье: {HealthPerLevel} - Оружие: {Weapon} - Бонусы: {string.Join('/', (IEnumerable<IBonus>)Bonuses)}";

}

public record Rogue() : Class( [new StealthAttack(), new IncreasedAgility(), new Poison()] , new Dagger(), 4, "Разбойник");

public record Warrior() : Class( [new ImpulseToAction(), new Shield(), new IncreasedStrength()] , new Sword(), 5, "Воин");

public record Barbarian() : Class( [new Rage(), new StoneSkin(), new IncreasedStamina()] , new Club(), 6, "Варвар");