

public class Poison : IDamageModifier
{
    public const int TurnsWithoutDamage = 1;

    public override string ToString() => "Яд";

    public int ModifyDamage(IReadOnlyAttributes targetAttributtes, DamageInfo damageInfo, int turn)
    {
        return turn - TurnsWithoutDamage;
    }
}
