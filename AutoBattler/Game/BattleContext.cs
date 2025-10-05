
using System.Linq;

public record BattleContext(DamageContext Attacker, DamageContext Target, int Turn)
{
    public int CalculateAttackerBonusDamage()
    {
        var bonuses = Attacker.DamageModifiers;
        return bonuses.Select(bonus => bonus.ModifyDamage(this)).Sum();
    }
}
