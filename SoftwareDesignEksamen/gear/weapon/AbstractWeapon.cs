namespace SoftwareDesignEksamen.weapon;

public abstract class AbstractWeapon
{

    public int Cost { get; protected init; }
    public int Damage { get; protected init; }
    public int Reach { get; protected init; }
    public int LifeSteal { get; protected init; }
    
    protected AbstractWeapon()
    {
        Cost = 0;
        Damage = 0;
        Reach = 0;
        LifeSteal = 0;
    }
}