using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace week02;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Add Bob, Tim, and Sue then rotate queue.
    // Expected Result: Bob, Tim, Sue, Bob
    // Defect(s) Found: Queue rotation was incorrect.
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var players = new TakingTurnsQueue();

        players.AddPerson("Bob");
        players.AddPerson("Tim");
        players.AddPerson("Sue");

        Assert.AreEqual("Bob", players.GetNextPerson());
        Assert.AreEqual("Tim", players.GetNextPerson());
        Assert.AreEqual("Sue", players.GetNextPerson());
        Assert.AreEqual("Bob", players.GetNextPerson());
    }

    [TestMethod]
    // Scenario: Add player midway through queue usage.
    // Expected Result: George is added correctly to rotation.
    // Defect(s) Found: New players were not inserted correctly.
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var players = new TakingTurnsQueue();

        players.AddPerson("Bob");
        players.AddPerson("Tim");
        players.AddPerson("Sue");

        Assert.AreEqual("Bob", players.GetNextPerson());
        Assert.AreEqual("Tim", players.GetNextPerson());

        players.AddPerson("George");

        Assert.AreEqual("Sue", players.GetNextPerson());
        Assert.AreEqual("Bob", players.GetNextPerson());
        Assert.AreEqual("Tim", players.GetNextPerson());
        Assert.AreEqual("George", players.GetNextPerson());
    }

    [TestMethod]
    // Scenario: Verify queue length updates correctly.
    // Expected Result: Length matches number of players.
    // Defect(s) Found: Queue length was not updating properly.
    public void TestTakingTurnsQueue_Length()
    {
        var players = new TakingTurnsQueue();

        Assert.AreEqual(0, players.Length);

        players.AddPerson("Bob");
        players.AddPerson("Sue");

        Assert.AreEqual(2, players.Length);
    }

    [TestMethod]
    // Scenario: Empty queue should throw exception.
    // Expected Result: InvalidOperationException is thrown.
    // Defect(s) Found: Empty queue did not throw correct exception.
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();

        try
        {
            players.GetNextPerson();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("Queue is empty", e.Message);
        }
    }
}