namespace SoftwareDesignEksamen.gear.chestPlate;

public abstract class AbstractChestPlate
{
    public int Armor { get; init; }
    public int Cost { get; set; }

    public AbstractChestPlate()
    {
        Armor = 0;
        Cost = 0;
    }
}