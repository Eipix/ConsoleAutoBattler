

public class Poison : IDamageModifier
{
    public const int TurnsWithoutDamage = 1;

    public override string ToString() => "Яд";

    public int ModifyDamage(BattleContext context)
    {
        return context.Turn - TurnsWithoutDamage;
    }
}
