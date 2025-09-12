/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: "The user shall specify the maximum size of the Customer Service Queue when it is created.
        // If the size is invalid (less than or equal to 0) then the size shall default to 10."
        // Expected Result:
        // 1. Size <= 0 Then Default to 10
        // 2. Size > 0 Then keep Size
        Console.WriteLine("Test 1");

        //1.
        var service1 = new CustomerService(-5);
        Console.WriteLine($"Size should be 10: {service1._maxSize}");
        //2.
        var service2 = new CustomerService(16);
        Console.WriteLine($"Size should be 16: {service2._maxSize}");

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: The AddNewCustomer method shall enqueue a new customer into the queue.
        // Expected Result: New customer is added and served using both methods.
        Console.WriteLine("Test 2");
        var service3 = new CustomerService(1);
        service3.AddNewCustomer();
        service3.ServeCustomer();

        // Defect(s) Found: 
        //Unhandled exception. System.ArgumentOutOfRangeException: Index was out of range. 
        // Must be non-negative and less than the size of the collection.
        //We needed to invert the execution order of the ServeCustomer() method.
        //var customer = _queue[0];
        //_queue.RemoveAt(0);


        Console.WriteLine("=================");
        // Test 3
        // Scenario: If the queue is full when trying to add a customer,
        //then an error message will be displayed.
        // Expected Result: If we try to add a customer at the position _maxSize + 1,
        // it will thrown an error.
        Console.WriteLine("Test 3");
        var service4 = new CustomerService(2);
        service4.AddNewCustomer();
        service4.AddNewCustomer();
        service4.AddNewCustomer();

        // Defect(s) Found: It allows the user to enter _maxSize + 1 customers.
        //Change _queue.Count > _maxSize to _queue.Count >= _maxSize


        Console.WriteLine("=================");
        Console.WriteLine("Test 4");
        // Test 4
        // Scenario: The ServeCustomer function shall dequeue the next
        // customer from the queue and display the details.
        //We can add two customers and dequeue them it should
        //Display the dequeued customers in the correct order
        var service5 = new CustomerService(2);
        //Add customers to the queue
        service5.AddNewCustomer();
        service5.AddNewCustomer();
        //Dequeue customers in the correct order.
        service5.ServeCustomer();
        service5.ServeCustomer();


        Console.WriteLine("=================");
        Console.WriteLine("Test 5");
        // Test 5
        // Scenario: If the queue is empty when trying to serve a customer, 
        // then an error message will be displayed.
        var service6 = new CustomerService(2);
        service6.ServeCustomer();

        // Defect(s) Found: An unhandled exception of type 'System.ArgumentOutOfRangeException'
        // occurred in System.Private.CoreLib.dll:'Index was out of range. 
        // Must be non-negative and less than the size of the collection.'
        // We are not checking if the queue is empty.



    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count > 0)
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
        else
        {
            Console.Write("No customers to serve. Queue is empty");
        }

    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}