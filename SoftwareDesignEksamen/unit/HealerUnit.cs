namespace SoftwareDesignEksamen.unit;

class HealerUnit : AbstractUnit
{
    public HealerUnit()
    {
        Description = "Healer";
        MaxHealth = 5;
        Damage = 1;
        Healing = 5;
        Armor = 0;
        Reach = 1;
        LifeSteal = 0;
        Cost = 10;
    }
}