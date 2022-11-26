namespace SoftwareDesignEksamen.gear.shield;

public abstract class Shield
{
    public int Armor { get; protected init; }
    public int Cost { get; protected init; }

    public Shield()
    {
        Cost = 0;
        Armor = 0;
    }
}