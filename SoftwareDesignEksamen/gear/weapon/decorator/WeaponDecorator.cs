using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.gear.weapon.decorator;

public abstract class WeaponDecorator : Weapon
{
    protected readonly Weapon _original;

    public WeaponDecorator(Weapon original)
    {
        _original = original;
        
        Cost = _original.Cost;
        Damage = _original.Damage;
        Reach = _original.Reach;
        LifeSteal = _original.LifeSteal;
        
    }
}