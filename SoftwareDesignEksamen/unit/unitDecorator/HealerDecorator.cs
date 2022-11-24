namespace SoftwareDesignEksamen.unit.unitDecorator;

public class HealerDecorator : UnitDecorator
{
    public HealerDecorator(AbstractUnit original) : base(original)
    {
        Healing = (int)(_original.Healing * 1.5);
        Damage = (int)(_original.Damage * 0.7);
    }
}