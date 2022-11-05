using SoftwareDesignEksamen.player;
using SoftwareDesignEksamen.ui;
using SoftwareDesignEksamen.unit;
using SoftwareDesignEksamen.unit.unitFactory;

namespace SoftwareDesignEksamen.gameManager;

public class GameManager
{
    #region Fields

    private Player _player1;

    private Player _player2;

    private readonly Ui _ui = new Ui();

    //private GameBoard _gameBoard;

    #endregion

    #region Methods

    public void StartGame()
    {
        PlayerInit();
        _ui.Message("Player one -> Name: " + _player1.Name + ", Gold: " + _player1.Gold);
        _ui.Message("Player two -> Name: " + _player2.Name + ", Gold: " + _player2.Gold + "\n");
        ArmyInit();
    }

    private void PlayerInit()
    {
        var name = _ui.AskQuestion("Enter player one name");
        _player1 = new Player(name, 100);
        name = _ui.AskQuestion("Enter player two name");
        _player2 = new Player(name, 100);
    }

    private void ArmyInit()
    {
        BuildArmy(_player1);
        BuildArmy(_player2);
    }

    private void BuildArmy(Player player)
    {
        List<string> baseUnits = new List<string>
        { // Change the cost to not beeing hardcoded, maybe import from json ??
            "DPS (10)",
            "Tank (10)",
            "Healer (10)"
        };

        _ui.Message(player.Name + ", choose the unit you want to add to your army");
        var unitFactory = new UnitFactory();
        bool run = true;
        while (run)
        {
            //Choose unit
            _ui.Message($"Your current gold is {player.Gold}");
            var playerUnitChoice = _ui.PrintMultipleChoice(baseUnits);

            // Pay, Create and  add unit. 
            var unit = unitFactory.CreateUnit((UnitEnum)playerUnitChoice);
            if (player.Gold >= unit.Cost)
            {
                player.Gold -= unit.Cost;
                unit.Name = _ui.AskQuestion("Enter the name you want on the unit:");
                player.AddUnit(unit);
                _ui.Clear();
                _ui.Message($"{unit.Description}-Unit added to your army");
            }
            else
            {
                _ui.Message("You dont have enough gold for that unit!");
            }
            
            // Show army
            _ui.Message("Your army currently contains");
            if (player.ListArmy().Count == 0)
            {
                _ui.Message("[No units]");
            }
            foreach (var armyUnit in player.ListArmy())
            {
                _ui.Message($"{armyUnit.Name}({armyUnit.Description})");
            }
            // GoldSack empty
            if (player.Gold == 0)
            {
                _ui.Message("Your out of gold!");
                break;
            }

            run = _ui.ReadBoolean("\nAdd more units", "yes", "no");
        }
    }


    private void GameBoardInit()
    {
    }

    private void UpdateGameBoard()
    {
    }

    private void Attack(Player attacker, Player defender)
    {
    }

    private void Turn()
    {
    }

    private void EndGame()
    {
    }

    private void SaveHighScore()
    {
    }

    private void BattleLog()
    {
    }

    #endregion
}