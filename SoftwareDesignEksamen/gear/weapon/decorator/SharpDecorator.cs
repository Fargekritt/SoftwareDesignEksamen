using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.gear.weapon.decorator;

public class SharpDecorator : AbstractWeaponDecorator
{
    public SharpDecorator(AbstractWeapon original) : base(original)
    {
        Damage = _original.Damage + 2;
    }
}