namespace SoftwareDesignEksamen.gear.chestPlate;

class ChestPlateDecorator : ChestPlate
{
    protected readonly ChestPlate _original;

    public ChestPlateDecorator(ChestPlate original)
    {
        _original = original;
        
        Cost = _original.Cost;
        Armor = _original.Armor;
    }
}