
public class InvincibilityToSlashing : IDamageReceiverModifier
{
    public override string ToString() => "Неуязвимость к рубящему оружию";

    public int ModifyDamageTaken(IReadOnlyAttributes target, DamageInfo damageInfo)
    {
        var characterDamageInfo = (CharacterDamageInfo)damageInfo;

        if (characterDamageInfo.Type is WeaponType.Slashing)
            return - damageInfo.WeaponDamage;

        return 0;
    }
}
