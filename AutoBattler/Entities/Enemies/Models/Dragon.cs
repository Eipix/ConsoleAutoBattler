
using System;

public class Dragon : Enemy
{
    public Dragon() : base(new Attributes(3, 3, 3), new LegendarySword(), 20, 4, "Дракон")
    {
        Color = ConsoleColor.DarkRed;
        AddBonus(new FireBreath());
    }
}
