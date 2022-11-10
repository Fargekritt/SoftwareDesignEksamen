using SoftwareDesignEksamen.unit;

namespace SoftwareDesignEksamen.army;

public class Army
{
    private int _combinedHealingPower = 0;
    public List<AbstractUnit> Units { get; set; } = new List<AbstractUnit>();

    public void AddUnit(AbstractUnit unit)
    {
        _combinedHealingPower += unit.Healing;
        Units.Add(unit);
    }

    public void AttackedBy(Army attacker)
    {
        var attackerUnit = attacker.Units[0]; 
        // foreach (var attackerUnit in attacker.Units)
        // {
            var damageDealt = 0;
            var damage = attackerUnit.Damage;

            for (int i = 0; i < Math.Min(attackerUnit.Reach, Units.Count); i++)
            {
                if (i > 1)
                {
                    damage = (damage * 90) / 100;
                }

                damageDealt += Units[i].TakeDamage(damage);
            }

            attackerUnit.DamageDealt(damageDealt);
        // }
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
        for(int i = Units.Count-1; i >= 0; i--)
        {
            if (Units[i].IsAlive()) continue;

            _combinedHealingPower -= Units[i].Healing;
            Units.RemoveAt(i);
        }
    }

    public bool IsAlive()
    {
        return Units.Count > 0;
    }
}