using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

public sealed class Character : Entity
{
    private readonly List<Class> _currentClasses = new();

    private Weapon? _weapon;

    public Weapon? Weapon => _weapon;

    public int SummaryLevel => _currentClasses.Sum(c => c.Level);

    public override DamageInfo DamageInfo => new CharacterDamageInfo(TotalAttributes, DamageModifiers, _weapon!.Type, _weapon.Damage);

    public Character() : base("Игрок") { }

    public override string ToString()
    {
        string classInfo = string.Join('/', _currentClasses.Select(c => c.Status));
        string bonuses = string.Join('/', _currentClasses.SelectMany(c => c.CurrentBonuses));
        string characteristics = $"Жизни: {Health}, Базовый урон - {DamageInfo.BaseDamage} Оружие - {Weapon}, {InitialAttributes}";

        return $"Статус - {classInfo}\nБонусы - {bonuses}\nХарактеристики - {characteristics}";
    }

    public override void Recovery()
    {
        LevelUpStamina();
        base.Recovery();
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (weapon is null)
            throw new InvalidOperationException($"Экипированное оружие не может быть равно null!");

        _weapon = weapon;
    }

    public void InitOrUpgradeClass(Class @class)
    {
        if (_currentClasses.Count > 0)
        {
            LevelUp(@class);
            return;
        }

        Init(global::Attributes.GenerateRandom(), @class.HealthPerLevel);
        _currentClasses.Add(@class);
        UpdateBonuses();
        _weapon = @class.Weapon;
    }

    public void Reset()
    {
        foreach (var @class in _currentClasses)
        {
            @class.Reset();
        }
        _currentClasses.Clear();
        base.Recovery();
    }

    private void LevelUp(Class @class)
    {
        if (SummaryLevel > GameConstants.MaxClassLevel)
            throw new InvalidOperationException($"Суммарное количество уровней класса не может превышать максимальное ({GameConstants.MaxClassLevel})!");

        if (_currentClasses.Contains(@class))
            @class.LevelUp();
        else
            _currentClasses.Add(@class);

        UpdateBonuses();
        Recovery();
    }

    private void UpdateBonuses()
    {
        ClearBonuses();

        foreach (var item in _currentClasses)
            AddBonuses(item.CurrentBonuses);
    }
}
