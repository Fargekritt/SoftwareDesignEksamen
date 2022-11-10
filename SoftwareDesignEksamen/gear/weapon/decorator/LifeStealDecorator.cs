using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.gear.weapon.decorator;

public class LifeStealDecorator : AbstractWeaponDecorator
{
    public LifeStealDecorator(AbstractWeapon original) : base(original)
    {
        LifeSteal = _original.LifeSteal + 30;
        Cost = _original.Cost + 3;
    }
}