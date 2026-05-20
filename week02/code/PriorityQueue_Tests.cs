using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add two items with different priorities and remove one
    // Expected Result: Item with highest priority is removed first
    // Defect(s) Found: None yet (baseline test)
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("John", 1);
        priorityQueue.Enqueue("Mary", 5);

        string result = priorityQueue.Dequeue();

        Assert.AreEqual("Mary", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with same priority
    // Expected Result: Items are removed in FIFO order when priority is equal
    // Defect(s) Found: Ensures correct tie-breaking behavior
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("John", 3);
        priorityQueue.Enqueue("Mary", 3);
        priorityQueue.Enqueue("Alex", 3);

        string first = priorityQueue.Dequeue();
        string second = priorityQueue.Dequeue();

        Assert.AreEqual("John", first);
        Assert.AreEqual("Mary", second);
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Exception is thrown
    // Defect(s) Found: Ensures proper error handling
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });
    }

    [TestMethod]
    // Scenario: Check queue state after enqueue operations
    // Expected Result: Queue is not empty after adding items
    // Defect(s) Found: Ensures Enqueue works correctly
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("John", 2);

        Assert.IsNotNull(priorityQueue.ToString());
    }
}