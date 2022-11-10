using SoftwareDesignEksamen.ui;

namespace SoftwareDesignEksamen.battleLog;

public class BattleLogger
{
    private static BattleLogger? _logger;
    private Ui _ui = Ui.CreateInstance();

    private BattleLogger()
    {
    }

    public static BattleLogger CreateInstance()
    {
        return _logger ??= new BattleLogger();
    }
    

    public void Info(string log)
    {
        _ui.Message(log);
    }
    
    public void Info(string log, ConsoleColor color)
    {
        _ui.Message(log, color);
    }
    
    
}