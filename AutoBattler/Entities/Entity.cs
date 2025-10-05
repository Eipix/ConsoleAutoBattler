using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Entity
{
    public readonly string Name;

    private List<IBonus> _currentBonuses = new();
    private Attributes _initialAttributes = Attributes.Zero;

    private int _initialHealth;
    private int _cumulativeStamina;
    private int _cumulativeDamage;

    private IEnumerable<IDamageReceiverModifier> DamageReceiverModifiers => _currentBonuses.OfType<IDamageReceiverModifier>();

    protected IReadOnlyList<IBonus> CurrentBonuses => _currentBonuses;
    protected IEnumerable<IDamageModifier> DamageModifiers => _currentBonuses.OfType<IDamageModifier>();

    public IReadOnlyAttributes InitialAttributes => _initialAttributes;
    public IReadOnlyAttributes BonusAttributes => _currentBonuses
        .OfType<IAttributesModifier>()
        .Select(attribute => attribute.ModifyAttributes())
        .Sum();
    public IReadOnlyAttributes TotalAttributes => _initialAttributes + (Attributes)BonusAttributes;

    public int Health => Math.Max(0, _initialHealth + _cumulativeStamina - _cumulativeDamage);
    public int Strength => _initialAttributes.Strength;
    public int Agility => _initialAttributes.Agility;
    public int Stamina => _initialAttributes.Stamina;
    public bool IsAlive => Health > 0;
    public bool IsDead => IsAlive is false;

    public abstract DamageContext DamageContext { get; }
    public virtual ConsoleColor ApplyDamageColor => GameConstants.Info;

    public Entity(string name) => Name = name;

    protected void Init(Attributes attributes, int health)
    {
        if (attributes is null || health < 0)
            throw new InvalidOperationException($"Invalid Values [{nameof(attributes)}:{attributes};{nameof(health)}{health}]");

        _initialAttributes = attributes;
        _initialHealth = health;
        _cumulativeStamina = _initialAttributes.Stamina;
    }

    public bool TryTakeDamage(BattleContext context, out DamageResults results)
    {
        if (context.Turn < 1)
            throw new InvalidOperationException($"{nameof(context.Turn)} must be non-zero positive number!");

        results = new DamageResults(0, 0, 0);

        if(IsMiss(context.Attacker.Attributes))
            return false;

        int attackerBonusDamage = context.CalculateAttackerBonusDamage();
        int targetDamageModifier = CalculateTargetDamageAdjustment(context);
        int processedDamage = context.Attacker.BaseDamage + targetDamageModifier + attackerBonusDamage;

        results = new DamageResults(processedDamage, attackerBonusDamage, targetDamageModifier);

        if (processedDamage < 0)
            return true;

        _cumulativeDamage += processedDamage;
        return true;
    }

    public virtual void Recovery() => _cumulativeDamage = 0;

    protected void LevelUpStamina() => _cumulativeStamina += TotalAttributes.Stamina;

    protected void AddBonus(IBonus bonus)
    {
        if (bonus is null)
            throw new InvalidOperationException("Присваеваемый бонус не может быть null!");

        _currentBonuses.Add(bonus);
    }

    protected void AddBonuses(IEnumerable<IBonus> bonuses)
    {
        if (bonuses is null)
            throw new NullReferenceException("IEnumerable<IBonus> bonuses не может быть null!");

        if(bonuses.Any() is false)
            throw new InvalidOperationException("Нельзя присвоить пустой IEnumerable!");

        _currentBonuses.AddRange(bonuses);
    }

    protected void ClearBonuses() => _currentBonuses.Clear();

    private bool IsMiss(IReadOnlyAttributes attacker)
    {
        var attributes = TotalAttributes;
        int chance = Random.Shared.Next(1, attacker.Agility + attributes.Agility + 1);
        return chance <= attributes.Agility;
    }

    private int CalculateTargetDamageAdjustment(BattleContext context)
    {
        int adjustmentDamage = 0;
        var modifiers = DamageReceiverModifiers;

        foreach (var modifier in modifiers)
        {
            adjustmentDamage += modifier.ModifyDamageTaken(context);
        }
        return adjustmentDamage;
    }
}
