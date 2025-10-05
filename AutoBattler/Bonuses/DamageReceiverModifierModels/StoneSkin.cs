
public class StoneSkin : IDamageReceiverModifier
{
    public override string ToString() => "Каменная кожа";

    public int ModifyDamageTaken(BattleContext context)
    {
        return -context.Target.Attributes.Stamina;
    }
}
