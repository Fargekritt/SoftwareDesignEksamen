using SoftwareDesignEksamen.battleLog;
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

    private readonly Ui _ui = Ui.CreateInstance();
    private BattleLogger _logger = BattleLogger.CreateInstance();

    //private GameBoard _gameBoard;

    #endregion

    #region Methods

    public void StartGame()
    {
        PlayerInit();
        _ui.Message("Player one -> Name: " + _player1.Name + ", Gold: " + _player1.Gold);
        _ui.Message("Player two -> Name: " + _player2.Name + ", Gold: " + _player2.Gold + "\n");
        ArmyInit();
        bool run = true;
        while (run)
        {
            Turn(_player1, _player2);
            Turn(_player2, _player1);

            if (!PlayersAlive())
            {
                run = false;
                EndGame();
            }

        }
        _ui.Message("================== TURN DONE ==================");
        foreach (var armyUnit in _player2.ListArmy())
        {
            _ui.Message($"===={armyUnit.Name}=======");
            _ui.Message($"{armyUnit}");
        }
    }

    private void EndGame()
    {
        _ui.Message("Game over lmao");
    }

    private void PlayerInit()
    {
        var name = _ui.AskQuestion("Enter player one name");
        _player1 = new Player(name, 100, _ui);
        name = _ui.AskQuestion("Enter player two name");
        _player2 = new Player(name, 100, _ui);
    }

    private void ArmyInit()
    {
        BuildArmy(_player1);
        BuildArmy(_player2);
    }

    private void BuildArmy(Player player)
    {
        List<string> baseUnits = new List<string>
        { // Change the cost to not being hardcoded, maybe import from json ??
            "DPS (10)",
            "Tank (10)",
            "Healer (10)",
            "RaidBoss"
        };
        player.BuildArmy(baseUnits);
    }


    private void GameBoardInit()
    {
    }

    private void UpdateGameBoard()
    {
    }

    private void Attack(Player attacker, Player defender)
    {
        defender.AttackedBy(attacker);
    }

    private void Turn(Player attacker, Player defender)
    {
        if (!attacker.IsAlive() || !defender.IsAlive())
        {
            return;
        }
        

        Attack(attacker, defender);
        attacker.HealingTurn();
        defender.Update();
        attacker.Update();
    }

    private bool PlayersAlive()
    {
        return _player1.IsAlive() && _player2.IsAlive();
    }

    private void SaveHighScore()
    {
    }

    private void BattleLog()
    {
    }

    #endregion
}