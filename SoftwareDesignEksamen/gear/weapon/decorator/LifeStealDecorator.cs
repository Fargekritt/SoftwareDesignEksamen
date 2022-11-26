using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.gear.weapon.decorator;

public class LifeStealDecorator : WeaponDecorator
{
    public LifeStealDecorator(Weapon original) : base(original)
    {
        LifeSteal = _original.LifeSteal + 30;
        Cost = _original.Cost + 10;
    }
}