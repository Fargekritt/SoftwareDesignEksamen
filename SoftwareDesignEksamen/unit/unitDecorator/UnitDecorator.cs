namespace SoftwareDesignEksamen.unit.unitDecorator;

public abstract class UnitDecorator:AbstractUnit
{
    protected readonly AbstractUnit _original;

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

class TankDecorator : UnitDecorator
{
    public TankDecorator(AbstractUnit original) : base(original)
    {
        Armor = (int)(_original.Armor * 1.5);
    }
}

class DpsDecorator : UnitDecorator
{
    public DpsDecorator(AbstractUnit original) : base(original)
    {
        Damage = (int)(_original.Damage *  1.2);
        Healing = (int)(_original.Healing * 0.2);
        Armor = (int)(_original.Armor * 0.5);
    }
}

class HealerDecorator : UnitDecorator
{
    public HealerDecorator(AbstractUnit original) : base(original)
    {
        Healing = _original.Healing * 2;
        Damage = (int)(_original.Damage * 0.7);
    }
}