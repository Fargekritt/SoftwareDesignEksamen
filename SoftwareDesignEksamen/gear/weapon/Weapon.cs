namespace SoftwareDesignEksamen.weapon;

public abstract class Weapon
{

    public int Cost { get; protected init; }
    public int Damage { get; protected init; }
    public int Reach { get; protected init; }
    public int LifeSteal { get; protected init; }
    
    protected Weapon()
    {
        Cost = 0;
        Damage = 0;
        Reach = 0;
        LifeSteal = 0;
    }
}