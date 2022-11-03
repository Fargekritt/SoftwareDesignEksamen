using SoftwareDesignEksamen.army;
using SoftwareDesignEksamen.unit;

namespace SoftwareDesignEksamen.player;

public class Player
{
    private Army _army;

    public Player(Army army, string name, int gold)
    {
        _army = army;
        Name = name;
        Gold = gold;
    }

    public string Name { get; set; }
    public int Gold { get; set; }

    // todo
    // maybe change this later on to not only give the first Unit but instead the next unit based by turn.
    public AbstractUnit GetNextUnit()
    {
        return _army.Units[0];
    }

    public void AttackedBy(AbstractUnit attacker)
    {
        _army.AttackedBy(attacker);
    }
}