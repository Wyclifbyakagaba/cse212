using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace week02;

[TestClass]
public class PriorityQueue_Tests
{
    [TestMethod]
    // Test Result: Queue object was created successfully.
    public void Test_QueueCreation()
    {
        var queue = new TakingTurnsQueue();

        Assert.IsNotNull(queue);
    }

    [TestMethod]
    // Test Result: Queue length updates correctly after adding people.
    public void Test_QueueLength()
    {
        var queue = new TakingTurnsQueue();

        queue.AddPerson("John");
        queue.AddPerson("Mary");

        Assert.AreEqual(2, queue.Length);
    }
}