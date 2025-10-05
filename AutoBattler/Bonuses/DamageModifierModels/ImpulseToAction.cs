

public class ImpulseToAction : IDamageModifier
{
    private const int FirstTurn = 1;

    public override string ToString() => "Порыв к действию";

    public int ModifyDamage(BattleContext context)
    {
        if(context.Turn is FirstTurn)
            return context.Attacker.WeaponDamage;

        return 0;
    }
}
