
public interface IDamageReceiverModifier : IBonus
{
    int ModifyDamageTaken(IReadOnlyAttributes target, DamageInfo damageInfo);
}
