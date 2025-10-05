
public class InvincibilityToSlashing : IDamageReceiverModifier
{
    public override string ToString() => "Неуязвимость к рубящему оружию";

    public int ModifyDamageTaken(BattleContext context)
    {
        var characterDamageContext = (CharacterDamageContext)context.Attacker;

        if (characterDamageContext.Type is WeaponType.Slashing)
            return - characterDamageContext.WeaponDamage;

        return 0;
    }
}
