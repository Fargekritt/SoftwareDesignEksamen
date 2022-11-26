using SoftwareDesignEksamen.database;

namespace SoftwareDesignEksamen.ui;

public interface IUi
{
    void PrintLeaderBoard(List<HighScoreDto> leaderBoard);
    void PrintGameBoard();
    int PrintStartMenu();
    int PrintMultipleChoice(List<string> questions);
    int ReadInt();
    string ReadString();
    bool ReadBoolean(string question, string yes, string no);
    string AskQuestion(string question);
    void PressToContinue();
    void Message(string message, bool newLine = true);
    void Message(string message, ConsoleColor color, bool newLine = true);
    void Clear();
}