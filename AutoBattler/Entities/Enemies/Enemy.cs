using System;
public abstract class Enemy : Entity
{
    public readonly Weapon Reward;
    public readonly int InitialDamage;

    public sealed override ConsoleColor ApplyDamageColor => GameConstants.Critical;
    public ConsoleColor Color { get; protected init; } = ConsoleColor.White;

    public sealed override DamageContext DamageContext => new( TotalAttributes, DamageModifiers, InitialDamage );

    public Enemy(Attributes attributes, Weapon reward, int health, int damage, string name) : base(name)
    {
        Reward = reward;
        InitialDamage = damage;
        Init(attributes, health);
    }

    public sealed override string ToString()
    {
        var damageInfo = DamageContext;
        string feature = CurrentBonuses.Count > 0 ? CurrentBonuses[0].ToString()! : "Нету";
        string characteristics = $"Жизни: {Health}, Базовый урон - {damageInfo.BaseDamage}, Урон оружия - {damageInfo.WeaponDamage}, {TotalAttributes}";

        return $"{Name}\nОсобенность - {feature}\nХарактеристики - {characteristics}";
    }
}
