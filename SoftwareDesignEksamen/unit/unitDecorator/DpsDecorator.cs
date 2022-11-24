namespace SoftwareDesignEksamen.unit.unitDecorator;

public class DpsDecorator : UnitDecorator
{
    public DpsDecorator(AbstractUnit original) : base(original)
    {
        Damage = (int)(_original.Damage *  1.5);
        Healing = (int)(_original.Healing * 0.2);
        Armor = (int)(_original.Armor * 0.5);
    }
}