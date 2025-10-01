
public class IncreasedStamina : IAttributesModifier
{
    private const int Stamina = 1;
    public override string ToString() => "Бонус к выносливости";

    public IReadOnlyAttributes ModifyAttributes()
    {
        return new Attributes(0, 0, Stamina);
    }
}
