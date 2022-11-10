using SoftwareDesignEksamen.battleLog;
using SoftwareDesignEksamen.unit;

namespace SoftwareDesignEksamen.army;

public class Army
{
    #region Fields

    private BattleLogger _logger = BattleLogger.CreateInstance();
    private int _combinedHealingPower = 0;
    private int _unitTurn = 0;

    #endregion

    #region Properties
    public List<AbstractUnit> Units { get; set; } = new List<AbstractUnit>();
    
    #endregion

    public void AddUnit(AbstractUnit unit)
    {
        _combinedHealingPower += unit.Healing;
        Units.Add(unit);
    }

    public void AttackedBy(Army attacker)
    {
        Attack(attacker.NextUnit());
    }

    private AbstractUnit NextUnit()
    {

        if (_unitTurn > Units.Count - 1)
        {
            _unitTurn = Units.Count - 1;
        }
        
        var unit = Units[_unitTurn];
        _unitTurn++;
        
        if (_unitTurn > Units.Count - 1)
        {
            _unitTurn = 0;
        }
        return unit;
    }

    private void Attack(AbstractUnit attackerUnit)
    {
        var damageDealt = 0;
        var damage = attackerUnit.Damage;

        for (int i = 0; i < Math.Min(attackerUnit.Reach, Units.Count); i++)
        {
            if (i > 1)
            {
                damage = (damage * 90) / 100;
            }

            _logger.Info($"{attackerUnit.Name} hits {Units[i].Name} for {damage} damage.");

            damageDealt += Units[i].TakeDamage(damage);
        }

        attackerUnit.DamageDealt(damageDealt);
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
            if (!Units[i].IsAlive())
            {
                _combinedHealingPower -= Units[i].Healing;
                Units.RemoveAt(i);
            }


        }
    }

    public bool IsAlive()
    {
        return Units.Count > 0;
    }
}