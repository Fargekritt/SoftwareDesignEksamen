namespace SoftwareDesignEksamen.unit;

public class HumanUnit : AbstractUnit
{
    public HumanUnit()
    {
        MaxHealth = 100;
        Damage = 50;
        Healing = 0;
        Armor = 0;
        Reach = 1;
        LifeSteal = 0;
        Cost = 10;
    }
}