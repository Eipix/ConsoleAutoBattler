
public class FireBreath : IDamageModifier
{
    public const int Damage = 3;
    public const int EveryTurnActivate = 3;

    public override string ToString() => "Огненное дыхание";

    public int ModifyDamage(BattleContext context)
    {
        if (context.Turn % EveryTurnActivate is 0)
            return Damage;

        return 0;
    }
}
