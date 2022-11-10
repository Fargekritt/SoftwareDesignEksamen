using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.gear.weapon.decorator;

class ReachDecorator : AbstractWeaponDecorator
{
    public ReachDecorator(AbstractWeapon original) : base(original)
    {
        Reach = _original.Reach + 1;
        Cost = _original.Cost + 5;
    }
}