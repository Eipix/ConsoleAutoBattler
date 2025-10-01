
public class StoneSkin : IDamageReceiverModifier
{
    public override string ToString() => "Каменная кожа";

    public int ModifyDamageTaken(IReadOnlyAttributes target, DamageInfo damageInfo)
    {
        return - target.Stamina;
    }
}
