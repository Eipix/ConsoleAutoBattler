

public class ImpulseToAction : IDamageModifier
{
    private const int FirstTurn = 1;

    public override string ToString() => "Порыв к действию";

    public int ModifyDamage(IReadOnlyAttributes targetAttributtes, DamageInfo damageInfo, int turn)
    {
        if(turn is FirstTurn)
            return damageInfo.WeaponDamage;

        return 0;
    }
}
