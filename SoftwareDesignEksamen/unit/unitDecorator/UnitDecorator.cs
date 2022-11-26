namespace SoftwareDesignEksamen.unit.unitDecorator;

public abstract class UnitDecorator:Unit
{
    protected readonly Unit _original;

    protected UnitDecorator(Unit original)
    {
        _original = original;
        
        MaxHealth = _original.MaxHealth;
        Damage = _original.Damage;
        Healing = _original.Healing;
        Armor = _original.Armor;
        Reach = _original.Reach;
        LifeSteal = _original.LifeSteal;
        Cost = _original.Cost;
    }
}