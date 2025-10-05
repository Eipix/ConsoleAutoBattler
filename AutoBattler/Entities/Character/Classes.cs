
using System;
using System.Collections.Generic;

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

public record Rogue() : Class( [new StealthAttack(), new AttributeModifier(new Attributes(0, 1, 0)), new Poison()] , new Dagger(), 4, "Разбойник");

public record Warrior() : Class( [new ImpulseToAction(), new Shield(), new AttributeModifier(new Attributes(1, 0, 0))] , new Sword(), 5, "Воин");

public record Barbarian() : Class( [new Rage(), new StoneSkin(), new AttributeModifier(new Attributes(0, 0, 1))] , new Club(), 6, "Варвар");