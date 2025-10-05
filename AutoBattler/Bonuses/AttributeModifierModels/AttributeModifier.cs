
public class AttributeModifier : IAttributesModifier
{
    private readonly IReadOnlyAttributes _bonus;

    public AttributeModifier(Attributes bonus) => _bonus = bonus;

    public override string ToString()
    {
        string name = "";

        if (_bonus.Strength > 0)
            name = "сила";
        else if (_bonus.Agility > 0)
            name = "ловкость";
        else if (_bonus.Stamina > 0)
            name = "выносливость";

        return $"Увеличенная {name}";
    }

    public IReadOnlyAttributes ModifyAttributes() => _bonus;
}
