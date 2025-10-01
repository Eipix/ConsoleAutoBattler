
using System;

public class Goblin : Enemy
{
    public Goblin() : base(new Attributes(1, 1, 1), new Dagger(), 5, 2, "Гоблин")
    {
        Color = ConsoleColor.Green;
    }
}
