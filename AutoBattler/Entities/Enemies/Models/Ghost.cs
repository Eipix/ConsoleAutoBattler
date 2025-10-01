

public class Ghost : Enemy
{
    public Ghost() : base(new Attributes(1, 3, 1), new Sword(), 6, 3, "Призрак")
    {
        AddBonus(new StealthAttack());
    }
}
