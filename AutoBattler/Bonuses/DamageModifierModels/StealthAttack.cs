
public class StealthAttack : IDamageModifier
{
    public const int DamageBonus = 1;

    public override string ToString() => "Скрытая атака";

    public int ModifyDamage(BattleContext context)
    {
        if (context.Attacker.Attributes.Agility >  context.Target.Attributes.Agility)
            return DamageBonus;

        return 0;
    }
}
