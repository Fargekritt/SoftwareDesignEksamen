using SoftwareDesignEksamen.battleLog;
using SoftwareDesignEksamen.unit;

namespace SoftwareDesignEksamen.army;

public class Army
{
    #region Fields

    private IBattleLogger _logger = BattleLogger.CreateInstance();
    private int _combinedHealingPower = 0;
    private int _unitTurn = 0;

    #endregion

    #region Properties
    public List<Unit> Units { get; set; } = new List<Unit>();
    
    #endregion

    /// <summary>
    /// Add a Unit to the army. if the unit has healing the army combinedHealingPower will also increase
    /// </summary>
    /// <param name="unit">Unit to be added to Army</param>
    public void AddUnit(Unit unit)
    {
        _combinedHealingPower += unit.Healing;
        Units.Add(unit);
    }

    /// <summary>
    /// Method to make the army be attacked by another Army
    /// </summary>
    /// <param name="attacker">Army that is attacking this army</param>
    public void AttackedBy(Army attacker)
    {
        Defend(attacker.NextUnit());
    }

    /// <summary>
    /// <c>NextUnit</c> returns the next unit from the army.
    /// </summary>
    /// <returns>AbstractUnit</returns>
    private Unit NextUnit()
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

    /// <summary>
    /// The actually attack from one unit
    /// </summary>
    /// <param name="attackerUnit">Unit to attack the army</param>
    private void Defend(Unit attackerUnit)
    {
        var damageDealt = 0;
        var damage = attackerUnit.Damage;

        for (int i = 0; i < Math.Min(attackerUnit.Reach, Units.Count); i++)
        {
            if (i >= 1)
            {
                damage = (damage * 90) / 100;
            }

            _logger.Info($"{attackerUnit.Name} hits {Units[i].Name} for {damage} damage.");

            damageDealt += Units[i].TakeDamage(damage);
        }

        attackerUnit.DamageDealt(damageDealt);
    }

    /// <summary>
    /// Heals all the units in the army with the combinedHealingPower of the army
    /// </summary>
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

    /// <summary>
    /// Removes all dead units from the army
    /// </summary>
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

    /// <summary>
    /// Check if the army has any units
    /// </summary>
    /// <returns>true if Units.Count > 0</returns>
    public bool IsAlive()
    {
        return Units.Count > 0;
    }
}