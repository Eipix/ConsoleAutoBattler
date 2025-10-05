using System;

public class Attributes(int strength, int agility, int stamina) : IReadOnlyAttributes
{
    public readonly static Attributes Zero = new(0, 0, 0);

    public const int RandomMinValue = 1;
    public const int RandomMaxValue = 3;

    public int Strength { get; set; } = strength;
    public int Agility { get; set; } = agility;
    public int Stamina { get; set; } = stamina;

    public static Attributes GenerateRandom()
    {
        return new Attributes(RandomValue(), RandomValue(), RandomValue());

        static int RandomValue() => Random.Shared.Next(RandomMinValue, RandomMaxValue + 1);
    }

    public override string ToString() => $"Сила: {Strength}, Ловкость: {Agility}, Выносливость: {Stamina}";

    public static Attributes operator+(Attributes a, Attributes b)
    {
        return new(a.Strength + b.Strength, a.Agility + b.Agility, a.Stamina + b.Stamina);
    }
}
