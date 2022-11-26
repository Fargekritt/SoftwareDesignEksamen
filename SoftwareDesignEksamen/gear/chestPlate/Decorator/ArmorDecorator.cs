namespace SoftwareDesignEksamen.gear.chestPlate;

class ArmorDecorator : ChestPlateDecorator
{
    
    public ArmorDecorator(ChestPlate original) : base(original)
    {

        Cost = _original.Cost;
        Armor = _original.Armor;
    }
}