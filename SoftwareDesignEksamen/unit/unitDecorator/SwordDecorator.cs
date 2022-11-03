namespace SoftwareDesignEksamen.unit.unitDecorator;

class SwordDecorator : UnitDecorator
{
    public SwordDecorator(AbstractUnit original) : base(original)
    {
        Damage += 2;
        Cost += 2;
    }

}