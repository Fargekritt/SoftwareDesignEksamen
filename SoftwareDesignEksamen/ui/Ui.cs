using SoftwareDesignEksamen.database;

namespace SoftwareDesignEksamen.ui;

public class Ui
{
    public int FontSize { get; set; }
    public ConsoleColor Color { get; set; }
    private static Ui? _ui;

    #region Methods

    private Ui()
    {
    }

    public static Ui CreateInstance()
    {
        return _ui ??= new Ui();
    }


    public void PrintLeaderBoard(List<HighScoreDto> leaderBoard)
    {
        
        Message("                              Leader Board!",ConsoleColor.Green);
        Message("+-=-=-=-=-=+=-=-=-=-=-=-=+=-=-=-=-=-=+=-=-=-=-=-=-=+=-=-=-=-=-=-=-=-+");
        Message("|   Username   | Total score | Highscore | Games played | Games won |");

        foreach (var highScore in leaderBoard)
        {
            string username = highScore.Username.PadRight(14).Substring(0, 14);
            Message("+--------------+-------------+-----------+--------------+-----------+");
            Message(
                "|" + username +
                "|" + highScore.TotalScore.ToString().PadLeft(13).Substring(0,13) +
                "|" + highScore.HighestScore.ToString().PadLeft(11).Substring(0,11) +
                "|" + highScore.GamesPlayed.ToString().PadLeft(14).Substring(0,14) +
                "|" + highScore.GamesWon.ToString().PadLeft(11).Substring(0,11) + "|"
            );
        }
        Message("+-=-=-=-=-=+=-=-=-=-=-=-=+=-=-=-=-=-=+=-=-=-=-=-=-=+=-=-=-=-=-=-=-=-+");
    }

    public void PrintGameBoard()
    {
    }

    public void PrintStartMenu()
    {
    }

    public int PrintMultipleChoice(List<string> questions)
    {
        for (var i = 0; i < questions.Count; i++)
        {
            var question = questions[i];
            Message($"{i + 1}. {question}");
        }

        while (true)
        {
            var readInt = ReadInt();
            if (readInt >= 1 && readInt < questions.Count + 1)
            {
                return readInt;
            }

            Message("Please enter a valid option");
        }
    }

    public int ReadInt()
    {
        var readString = ReadString();
        int.TryParse(readString, out var n);
        return n;
    }

    public string ReadString()
    {
        var readString = Console.ReadLine();
        return readString ?? "";
    }

    public bool ReadBoolean(string question, string yes, string no)
    {
        while (true)
        {
            var answer = AskQuestion(question + " " + yes + " / " + no).ToLower();
            if (answer == yes.ToLower())
            {
                return true;
            }

            if (answer == no.ToLower())
            {
                return false;
            }

            Message("Invalid Input");
        }
    }

    public string AskQuestion(string question)
    {
        Message(question);
        return ReadString();
    }

    // Print message to console

    public void Message(string message)
    {
        Console.WriteLine(message);
    }

    public void Message(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void Clear()
    {
        Console.Clear();
    }

    #endregion
}