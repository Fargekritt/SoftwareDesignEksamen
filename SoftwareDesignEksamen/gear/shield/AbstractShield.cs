namespace SoftwareDesignEksamen.gear.shield;

public abstract class AbstractShield
{
    public int Armor { get; protected init; }
    public int Cost { get; protected init; }

    public AbstractShield()
    {
        Cost = 0;
        Armor = 0;
    }
}