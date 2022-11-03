namespace SoftwareDesignEksamen.unit.unitDecorator;

public abstract class UnitDecorator:AbstractUnit
{
    private readonly AbstractUnit _original;

    protected UnitDecorator(AbstractUnit original)
    {
        _original = original;
        
        MaxHealth = _original.MaxHealth;
        Damage = _original.Damage;
        Healing = _original.Healing;
        Armor = _original.Armor;
        Reach = _original.Reach;
        LifeSteal = _original.LifeSteal;
    }
}