using SoftwareDesignEksamen.unit;

namespace SoftwareDesignEksamen.army;

public class Army
{
    public List<AbstractUnit> Units { get; set; }

    public void AddUnit(AbstractUnit unit)
    {
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
        
    }

    public void Update()
    {
        ClearDead();
    }

    private void ClearDead()
    {
        foreach (var unit in Units)
        {
            if (!unit.IsAlive())
            {
                Units.Remove(unit);
            }
        }
    }
}