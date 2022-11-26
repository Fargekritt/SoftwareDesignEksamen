namespace SoftwareDesignEksamen.gear.chestPlate;

public abstract class ChestPlate
{
    public int Armor { get; protected init; }
    public int Cost { get; protected init; }

    public ChestPlate()
    {
        Armor = 0;
        Cost = 0;
    }
}