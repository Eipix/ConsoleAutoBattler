
using System;

public class Skeleton : Enemy
{
    public Skeleton() : base(new Attributes(2, 2, 1), new Club(), 10, 2, "Скелет")
    {
        Color = ConsoleColor.Gray;
        AddBonus(new CrushingVulnerability());
    }
}
