namespace SoftwareDesignEksamen.unit;

public class HumanUnit : AbstractUnit
{
    public HumanUnit()
    {
        MaxHealth = 10;
        Damage = 5;
        Healing = 0;
        Armor = 0;
        Reach = 1;
        LifeSteal = 0;
        Cost = 10;
    }
}