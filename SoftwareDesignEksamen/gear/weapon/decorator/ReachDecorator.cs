using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.gear.weapon.decorator;

public class ReachDecorator : WeaponDecorator
{
    public ReachDecorator(Weapon original) : base(original)
    {
        Reach = _original.Reach + 1;
        Cost = _original.Cost + 5;
    }
}