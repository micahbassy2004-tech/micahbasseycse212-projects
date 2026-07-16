using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: Item with the highest priority is removed first.
    // Defect(s) Found: The Dequeue method did not always examine every item in the queue,
    // causing it to miss the highest-priority item if it was the last element. It also did
    // not remove the dequeued item from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 3);

        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add two items with the same highest priority.
    // Expected Result: The first item added is removed first (FIFO).
    // Defect(s) Found: The Dequeue method did not preserve FIFO order when multiple
    // items had the same highest priority because it selected the most recently
    // encountered item instead of the first one. It also failed to remove the
    // dequeued item from the queue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 2);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Remove from an empty queue.
    // Expected Result: InvalidOperationException is thrown.
    // Defect(s) Found: No defects found. The correct InvalidOperationException
    // was thrown when attempting to dequeue from an empty queue.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );
    }
}