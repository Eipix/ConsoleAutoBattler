

using Extensions;
using System.Collections.Generic;
using System.Linq;

public record DamageInfo(IReadOnlyAttributes AttackerAttributes, IEnumerable<IDamageModifier> Bonuses, int WeaponDamage)
{
    public int Strength => AttackerAttributes.Strength;
    public int Agility => AttackerAttributes.Agility;
    public int Stamina => AttackerAttributes.Stamina;
    public int BaseDamage => WeaponDamage + Strength;

    public int GetAttackerBonusDamage(IReadOnlyAttributes target, int round)
    {
        return Bonuses.Select(bonus => bonus.ModifyDamage(target, this, round)).Sum();
    }
}

public record CharacterDamageInfo(IReadOnlyAttributes AttackerAttributes, IEnumerable<IDamageModifier> Bonuses, WeaponType Type, int WeaponDamage)
            : DamageInfo(AttackerAttributes, Bonuses, WeaponDamage);