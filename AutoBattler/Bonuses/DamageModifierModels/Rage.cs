
public class Rage : IDamageModifier
{
    public const int StepDuration = 3;
    public const int DuringRageDamage = 2;
    public const int AfterRageDamage = -1;

    public override string ToString() => "Ярость";

    public int ModifyDamage(IReadOnlyAttributes targetAttributtes, DamageInfo damageInfo, int turn)
    {
        if(turn <= StepDuration)
            return DuringRageDamage;

        return AfterRageDamage;
    }
}
