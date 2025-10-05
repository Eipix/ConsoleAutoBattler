
public class Shield : IDamageReceiverModifier
{
    private const int DamageReduction = 3;

    public override string ToString() => "Щит";

    public int ModifyDamageTaken(BattleContext context)
    {
        if (context.Target.Attributes.Strength > context.Attacker.Attributes.Strength)
            return - DamageReduction;

        return 0;
    }
}
