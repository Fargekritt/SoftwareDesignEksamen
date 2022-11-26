using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.gear.weapon.decorator;

public class SharpDecorator : WeaponDecorator
{
    public SharpDecorator(Weapon original) : base(original)
    {
        Damage = _original.Damage + 2;
        Cost = _original.Cost + 2;
    }
}