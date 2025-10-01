
public class StealthAttack : IDamageModifier
{
    public const int DamageBonus = 1;

    public override string ToString() => "Скрытая атака";

    public int ModifyDamage(IReadOnlyAttributes targetAttributtes, DamageInfo damageInfo, int round)
    {
        if (damageInfo.Agility >  targetAttributtes.Agility)
            return DamageBonus;

        return 0;
    }
}
