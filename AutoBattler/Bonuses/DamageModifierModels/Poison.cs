

public class Poison : IDamageModifier
{
    public const int StepActivation = 2;

    private int _damage = 1;

    public override string ToString() => "Яд";

    public int ModifyDamage(IReadOnlyAttributes targetAttributtes, DamageInfo damageInfo, int turn)
    {
        if (turn >= StepActivation)
            return _damage++;

        return 0;
    }
}
