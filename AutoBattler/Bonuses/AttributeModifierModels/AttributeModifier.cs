
public class AttributeModifier : IAttributesModifier, IBonus
{
    private readonly IReadOnlyAttributes _bonus;

    public AttributeModifier(Attributes bonus) => _bonus = bonus;

    public IReadOnlyAttributes ModifyAttributes() => _bonus;
}
