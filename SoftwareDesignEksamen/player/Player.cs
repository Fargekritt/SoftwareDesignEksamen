using SoftwareDesignEksamen.army;
using SoftwareDesignEksamen.ui;
using SoftwareDesignEksamen.unit;
using SoftwareDesignEksamen.unit.unitFactory;

namespace SoftwareDesignEksamen.player;

public class Player
{
    private Army _army;
    private readonly Ui _ui;



    public Player(string name, int gold, Ui ui)
    {
        Name = name;
        Gold = gold;
        _ui = ui;
        _army = new Army();
    }

    public string Name { get; set; }
    public int Gold { get; set; }

    // todo
    // maybe change this later on to not only give the first Unit but instead the next unit based by turn.
    public AbstractUnit GetNextUnit()
    {
        return _army.Units[0];
    }

    public void HealingTurn()
    {
        _army.HealingTurn();
    }

    public void AttackedBy(Player attacker)
    {
        _army.AttackedBy(attacker._army);
    }

    public void AddUnit(AbstractUnit unit)
    {
        _army.AddUnit(unit);
    }

    public List<AbstractUnit> ListArmy()
    {
        return _army.Units;
    }

    public void BuildArmy(List<string> unitTypes)
    {
        _ui.Message(Name + ", choose the unit you want to add to your army");
        var unitFactory = new UnitFactory();
        bool run = true;
        while (run)
        {
            //Choose unit
            _ui.Message($"Your current gold is {Gold}");
            var playerUnitChoice = _ui.PrintMultipleChoice(unitTypes);

            // Pay, Create and  add unit. 
            var unit = unitFactory.CreateUnit((UnitEnum)playerUnitChoice);
            if (Gold >= unit.Cost)
            {
                Gold -= unit.Cost;
                unit.Name = _ui.AskQuestion("Enter the name you want on the unit:");
                AddUnit(unit);
                _ui.Clear();
                _ui.Message($"{unit.Description}-Unit added to your army");
            }
            else
            {
                _ui.Message("You dont have enough gold for that unit!");
            }

            // Show army
            _ui.Message("Your army currently contains");
            if (ListArmy().Count == 0)
            {
                _ui.Message("[No units]");
            }

            foreach (var armyUnit in ListArmy())
            {
                _ui.Message("===========");
                _ui.Message($"{armyUnit}");
            }

            // GoldSack empty
            if (Gold == 0)
            {
                _ui.Message("Your out of gold!");
                break;
            }

            run = _ui.ReadBoolean("\nAdd more units", "yes", "no");
        }
    }
    
    public void Update()
    {
        _army.Update();
    }

    public bool IsAlive()
    {
        return _army.IsAlive();
    }
}
