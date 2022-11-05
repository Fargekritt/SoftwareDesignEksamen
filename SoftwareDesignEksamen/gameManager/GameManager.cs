using SoftwareDesignEksamen.player;
using SoftwareDesignEksamen.ui;

namespace SoftwareDesignEksamen.gameManager;

public class GameManager
{
    private Player _player1;
    private Player _player2;

    private readonly Ui _ui = new Ui();
    //private GameBoard _gameBoard;

    #region Methods

    public void StartGame()
    {
        PlayerInit();
        _ui.Message("Player one: "+_player1.Name + ", Gold: "+_player1.Gold);
        _ui.Message("Player two: "+_player2.Name + ", Gold: "+_player2.Gold);
        var questions = new List<string>
        {
            "Pizza",
            "Burger",
            "Cake"
        };
        _ui.PrintMultipleChoice(questions);
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