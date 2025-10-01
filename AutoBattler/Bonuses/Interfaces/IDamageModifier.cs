
public interface IDamageModifier : IBonus
{
    int ModifyDamage(IReadOnlyAttributes targetAttributtes, DamageInfo damageInfo, int turn);
}
