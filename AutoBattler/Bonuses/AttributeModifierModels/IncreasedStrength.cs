
public class IncreasedStrength : IAttributesModifier
{
    private const int Strength = 1;

    public override string ToString() => "Бонус к силе";

    public IReadOnlyAttributes ModifyAttributes()
    {
        return new Attributes(Strength, 0, 0);
    }
}
