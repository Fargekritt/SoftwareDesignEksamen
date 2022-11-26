using SoftwareDesignEksamen.battleLog;
using SoftwareDesignEksamen.database;
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

    private Db _database = new Db("leaderBoard");

    private readonly IUi _ui = Ui.CreateInstance();
    private IBattleLogger _logger = BattleLogger.CreateInstance();

    //private GameBoard _gameBoard;

    #endregion

    #region Methods

    /// <summary>
    /// Starts the game loop itself
    /// </summary>
    public void StartGame()
    {
        _database.CreateDbAndTable();
        
        bool startGame = false;
        
        while (!startGame)
        {
            int choice = _ui.PrintStartMenu();
            switch (choice)
            {
                case 1 :
                    startGame = true;
                    break;
                case 2: 
                    _ui.PrintLeaderBoard(_database.GetLeaderBoard());
                    _ui.PressToContinue();
                    _ui.Clear();
                    break;
                case 3:
                    break;
            }
        }
        
        PlayerInit();
        _ui.Message("+-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=+", ConsoleColor.DarkBlue);
        _ui.Message("Player one -> Name: " + _player1.Name + ", Gold: " + _player1.Gold);
        _ui.Message("Player two -> Name: " + _player2.Name + ", Gold: " + _player2.Gold );
        _ui.Message("+-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=+", ConsoleColor.DarkBlue);
        _ui.Message("");
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
    }

    /// <summary>
    /// Ends the game. Updates the scoreboard, with the correct values based on the winner 
    /// </summary>
    private void EndGame()
    {
        _ui.Message("Game over lmao");
        int score = 100;
        var winner = _player1.IsAlive();
        if (winner)
        {
            score += _player1.Gold - _player2.Gold;
            _ui.Message($"{_player1.Name} Won the game", ConsoleColor.Blue);
            _database.UpdateScoreBoard(_player1.Name, score, true);
            _database.UpdateScoreBoard(_player2.Name, 0, false);
        }
        else
        {
            score += _player2.Gold - _player1.Gold;
            _ui.Message($"{_player2.Name} Won the game", ConsoleColor.Blue);
            _database.UpdateScoreBoard(_player2.Name, score, true);
            _database.UpdateScoreBoard(_player1.Name, 0, false);
        }
        // USE IS ALIVE ???
    }

    /// <summary>
    /// Inits the players. with names from the user
    /// </summary>
    private void PlayerInit()
    {
        var name = _ui.AskQuestion("Enter player one name");
        _player1 = new Player(name, 100, _ui);
        name = _ui.AskQuestion("Enter player two name");
        _player2 = new Player(name, 100, _ui);
    }

    /// <summary>
    /// Builds the armies for both the players
    /// </summary>
    private void ArmyInit()
    {
        BuildArmy(_player1);
        BuildArmy(_player2);
    }

    private void BuildArmy(Player player)
    {
        List<string> baseUnits = new List<string>
        {
            // Change the cost to not being hardcoded, maybe import from json ??
            "DPS (12)",
            "Tank (22)",
            "Healer (10)",
            "RaidBoss (37)"
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
        _ui.PressToContinue();
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