using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.weapon;

public class Sword : AbstractWeapon
{
    public Sword()
    {
        Cost = 2;
        Damage = 5;
        Reach = 0;
        LifeSteal = 0;
    }
}