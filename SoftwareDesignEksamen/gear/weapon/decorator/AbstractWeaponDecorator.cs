using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.gear.weapon.decorator;

public abstract class AbstractWeaponDecorator : AbstractWeapon
{
    protected readonly AbstractWeapon _original;

    public AbstractWeaponDecorator(AbstractWeapon original)
    {
        _original = original;
        
        Cost = _original.Cost;
        Damage = _original.Damage;
        Reach = _original.Reach;
        LifeSteal = _original.LifeSteal;
        
    }
}