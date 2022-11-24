
using SoftwareDesignEksamen.database;

namespace NunitTests;

public class DatabaseTests
{
    
    [Test]
    public void TestLeaderBoard()
    {
        var database = new Db("testDb");
        database.DropLeaderBoard();
        database.CreateDbAndTable();
        
        database.UpdateScoreBoard("TestUser", 10, true);
        Assert.Multiple(() =>
        {
            Assert.That(database.GetLeaderBoard()[0].Username, Is.EqualTo("TestUser"));
            Assert.That(database.GetLeaderBoard()[0].TotalScore, Is.EqualTo(10));
            Assert.That(database.GetLeaderBoard()[0].GamesPlayed, Is.EqualTo(1));
            Assert.That(database.GetLeaderBoard()[0].GamesWon, Is.EqualTo(1));
            Assert.That(database.GetLeaderBoard()[0].HighestScore, Is.EqualTo(10));
        });
        
        database.UpdateScoreBoard("TestUser", 11, true);
        Assert.Multiple(() =>
        {
            Assert.That(database.GetLeaderBoard()[0].Username, Is.EqualTo("TestUser"));
            Assert.That(database.GetLeaderBoard()[0].TotalScore, Is.EqualTo(21));
            Assert.That(database.GetLeaderBoard()[0].GamesPlayed, Is.EqualTo(2));
            Assert.That(database.GetLeaderBoard()[0].GamesWon, Is.EqualTo(2));
            Assert.That(database.GetLeaderBoard()[0].HighestScore, Is.EqualTo(11));
        });
        
        database.UpdateScoreBoard("SecondTestUser", 15, true);
        Assert.Multiple(() =>
        {
            Assert.That(database.GetLeaderBoard()[0].Username, Is.EqualTo("SecondTestUser"));
            Assert.That(database.GetLeaderBoard()[0].TotalScore, Is.EqualTo(15));
            Assert.That(database.GetLeaderBoard()[0].GamesPlayed, Is.EqualTo(1));
            Assert.That(database.GetLeaderBoard()[0].GamesWon, Is.EqualTo(1));
            Assert.That(database.GetLeaderBoard()[0].HighestScore, Is.EqualTo(15));
        });
        
        database.UpdateScoreBoard("TestUser", 20, true);
        Assert.Multiple(() =>
        {
            Assert.That(database.GetLeaderBoard()[0].Username, Is.EqualTo("TestUser"));
            Assert.That(database.GetLeaderBoard()[0].TotalScore, Is.EqualTo(41));
            Assert.That(database.GetLeaderBoard()[0].GamesPlayed, Is.EqualTo(3));
            Assert.That(database.GetLeaderBoard()[0].GamesWon, Is.EqualTo(3));
            Assert.That(database.GetLeaderBoard()[0].HighestScore, Is.EqualTo(20));
        });
        
        database.DropLeaderBoard();
    }
}