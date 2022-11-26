using SoftwareDesignEksamen.weapon;

namespace SoftwareDesignEksamen.unit.unitFactory;

public class Spear : Weapon
{
    public Spear()
    {
        Cost = 2;
        Damage = 30;
        Reach = 1;
    }
}