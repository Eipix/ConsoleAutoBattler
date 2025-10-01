
public class IncreasedAgility : IAttributesModifier
{
    private const int Agility = 1;

    public override string ToString() => "Бонус к ловкости";

    public IReadOnlyAttributes ModifyAttributes()
    {
        return new Attributes(0, Agility, 0);
    }
}
