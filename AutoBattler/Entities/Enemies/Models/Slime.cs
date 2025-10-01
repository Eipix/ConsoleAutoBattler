
using System;

public class Slime : Enemy
{
    public Slime() : base(new Attributes(3, 1, 2), new Spear(), 8, 1, "Слайм")
    {
        Color = ConsoleColor.Blue;
        AddBonus(new InvincibilityToSlashing());
    }
}
