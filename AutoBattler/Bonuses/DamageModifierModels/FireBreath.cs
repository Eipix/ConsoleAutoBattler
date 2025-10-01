
public class FireBreath : IDamageModifier
{
    public const int Damage = 3;
    public const int EveryTurnActivate = 3;

    public override string ToString() => "Огненное дыхание";

    public int ModifyDamage(IReadOnlyAttributes targetAttributtes, DamageInfo damageInfo, int turn)
    {
        if (turn % EveryTurnActivate is 0)
            return Damage;

        return 0;
    }
}
