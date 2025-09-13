using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function shall add an item (or any number of items)
    // (which contains both data and priority) to the back of the queue.
    //Add 3 items with data and priority
    // Expected Result: "[item1 (Pri:5), item2 (Pri:3), item3 (Pri:7)]"
    // Defect(s) Found: No bugs
    public void TestPriorityQueue_1()
    {
        PriorityQueue priorityQueueTest = new PriorityQueue();

        priorityQueueTest.Enqueue("item1", 5);
        priorityQueueTest.Enqueue("item2", 3);
        priorityQueueTest.Enqueue("item3", 7);

        string expectedResult = "[item1 (Pri:5), item2 (Pri:3), item3 (Pri:7)]";
        Assert.AreEqual(expectedResult, priorityQueueTest.ToString());
    }

    [TestMethod]
    // Scenario: The Dequeue function shall remove the item with
    // the highest priority and return its value.
    //If there are more than one item with the highest priority,
    // then the item closest to the front of the queue will be removed
    // and its value returned.
    // Expected Result: "item3"
    // Defect(s) Found: We were not removing the item from the queue
    //We were not checking the last item in the collection
    //We were not stopping at the closest highest priority item
    //But at the farthest
    public void TestPriorityQueue_2()
    {
        PriorityQueue priorityQueueTest2 = new PriorityQueue();

        priorityQueueTest2.Enqueue("item1", 5);
        priorityQueueTest2.Enqueue("item2", 3);
        priorityQueueTest2.Enqueue("item3", 7);
        priorityQueueTest2.Enqueue("item4", 7);
        priorityQueueTest2.Enqueue("item5", 7);

        string expectedResult = "item3";

        Assert.AreEqual(expectedResult, priorityQueueTest2.Dequeue().ToString());
    }


    [TestMethod]
    //Scenario: If the queue is empty, then an error exception shall be thrown. 
    // This exception should be an InvalidOperationException with a message
    // of "The queue is empty."
    //Expected Result: An error is thrown when the queue is empty with a message of:
    //"The queue is empty."
    //Defect(s) Found: No bugs
    public void TestPriorityQueue_3()
    {
        PriorityQueue priorityQueueTest3 = new PriorityQueue();

        try
        {
            priorityQueueTest3.Dequeue();
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    // Add more test cases as needed below.
}