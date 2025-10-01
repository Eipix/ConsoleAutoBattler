
using System;

public class Golem : Enemy
{
    public Golem() : base(new Attributes(3, 1, 3), new Axe(), 10, 1, "Голем")
    {
        Color = ConsoleColor.Yellow;
        AddBonus(new StoneSkin());
    }
}
