using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add two items with different priorities and remove one
    // Expected Result: Item with highest priority is removed first
    // Defect(s) Found: Original code failed to always remove the highest priority item correctly.
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
    // Defect(s) Found: Queue originally violated FIFO behavior for equal priorities.
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
    // Scenario: Remove from an empty queue
    // Expected Result: InvalidOperationException is thrown with exact required message
    // Defect(s) Found: Exception handling and message were not verified.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (System.Exception e)
        {
            Assert.Fail(
                string.Format(
                    "Unexpected exception of type {0} caught: {1}",
                    e.GetType(),
                    e.Message
                )
            );
        }
    }

    [TestMethod]
    // Scenario: Add several items with mixed priorities
    // Expected Result: Highest priorities removed first while preserving FIFO for ties
    // Defect(s) Found: Priority ordering was inconsistent.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("John", 1);
        priorityQueue.Enqueue("Mary", 5);
        priorityQueue.Enqueue("Alex", 5);
        priorityQueue.Enqueue("Sue", 2);

        string first = priorityQueue.Dequeue();
        string second = priorityQueue.Dequeue();
        string third = priorityQueue.Dequeue();

        Assert.AreEqual("Mary", first);
        Assert.AreEqual("Alex", second);
        Assert.AreEqual("Sue", third);
    }

    [TestMethod]
    // Scenario: Add one item and remove it
    // Expected Result: Same item is returned
    // Defect(s) Found: Ensures enqueue and dequeue work together correctly.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("OnlyItem", 10);

        string result = priorityQueue.Dequeue();

        Assert.AreEqual("OnlyItem", result);
    }
}