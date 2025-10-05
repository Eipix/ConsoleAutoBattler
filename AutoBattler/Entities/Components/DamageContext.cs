

using Extensions;
using System.Collections.Generic;
using System.Linq;

public record DamageContext(IReadOnlyAttributes Attributes, IEnumerable<IDamageModifier> DamageModifiers, int WeaponDamage)
{
    public int Strength => Attributes.Strength;
    public int Agility => Attributes.Agility;
    public int Stamina => Attributes.Stamina;
    public int BaseDamage => WeaponDamage + Strength;
}

public record CharacterDamageContext(IReadOnlyAttributes Attributes, IEnumerable<IDamageModifier> DamageModifiers, WeaponType Type, int WeaponDamage)
            : DamageContext(Attributes, DamageModifiers, WeaponDamage);