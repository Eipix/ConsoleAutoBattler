
public abstract record Weapon(int Damage, WeaponType Type, string Name, string TypeName)
{
    public sealed override string ToString() => $"{Name} (Тип: {TypeName}, Урон: {Damage})";
}


public record Sword() : Weapon(3, WeaponType.Slashing, "Меч", "Рубящий");

public record Club() : Weapon(3, WeaponType.Crushing, "Дубина", "Дробящий");

public record Dagger() : Weapon(2, WeaponType.Piercing, "Кинжал", "Колющий");

public record Axe() : Weapon(4, WeaponType.Slashing, "Топор", "Рубящий");

public record Spear() : Weapon(3, WeaponType.Piercing, "Копье", "Колющий");

public record LegendarySword() : Weapon(5, WeaponType.Slashing, "Легендарный Меч", "Рубящий");