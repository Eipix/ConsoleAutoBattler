
public class Shield : IDamageReceiverModifier
{
    private const int DamageReduction = 3;

    public override string ToString() => "Щит";

    public int ModifyDamageTaken(IReadOnlyAttributes target, DamageInfo damageInfo)
    {
        if (target.Strength > damageInfo.Strength)
            return - DamageReduction;

        return 0;
    }
}
