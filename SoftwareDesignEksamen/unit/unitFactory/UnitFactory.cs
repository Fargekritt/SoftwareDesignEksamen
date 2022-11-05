using SoftwareDesignEksamen.unit.unitDecorator;

namespace SoftwareDesignEksamen.unit.unitFactory;

public class UnitFactory
{
    public AbstractUnit? CreateUnit(UnitEnum unit)
    {
        switch (unit)
        {
            case UnitEnum.DPS: return new DpsUnit();
            case UnitEnum.TANK: return new TankUnit();
            case UnitEnum.HEALER: return new HealerUnit();
            default: return null;
        }
    }

    public AbstractUnit? UpgradeUnit(AbstractUnit unit, DecoratorEnum upgrade)
    {
        switch (upgrade)
        {
            // case DecoratorEnum.SWORD: return new SwordDecorator(unit);
            // case DecoratorEnum.SHIELD: return new ShieldDecorator(unit);
            default: return unit;
        }
    }
}