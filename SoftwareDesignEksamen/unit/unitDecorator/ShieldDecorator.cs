namespace SoftwareDesignEksamen.unit.unitDecorator;

class ShieldDecorator : UnitDecorator
{
    public ShieldDecorator(AbstractUnit original) : base(original)
    {
        Armor += 2;
        Cost += 2;
    }
}