namespace SoftwareDesignEksamen.unit.unitDecorator;

public class TankDecorator : UnitDecorator
{
    public TankDecorator(AbstractUnit original) : base(original)
    {
        Armor = (int)(_original.Armor * 1.4);
        Damage = (int)(_original.Damage * 0.8);
    }
}