namespace SoftwareDesignEksamen.battleLog;

public interface IBattleLogger
{
    void Info(string log);
    void Info(string log, ConsoleColor color);
}