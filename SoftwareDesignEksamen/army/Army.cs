using SoftwareDesignEksamen.unit;

namespace SoftwareDesignEksamen.army;

public class Army
{
    private int _combinedHealingPower;
    public List<AbstractUnit> Units { get; set; }

    public void AddUnit(AbstractUnit unit)
    {
        _combinedHealingPower += unit.Healing;
        Units.Add(unit);
    }

    public void AttackedBy(AbstractUnit attacker)
    {
        var defender = Units[0];
        var damageDealt = defender.TakeDamage(attacker.Damage);
        attacker.DamageDealt(damageDealt);
    }

    public void HealingTurn()
    {
        foreach (var unit in Units)
        {
            unit.Heal(_combinedHealingPower);
        }
    }

    public void Update()
    {
        ClearDead();
    }

    private void ClearDead()
    {
        foreach (var unit in Units)
        {
            if (unit.IsAlive())  continue;
            
            _combinedHealingPower -= unit.Healing;
            Units.Remove(unit);
        }
    }
}