public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Do not add check for positivity since we assumed that above
        //number and length are positive
        //We can return an expression so we avoid declaring new variables
        //Enumerable.Range(1, length) will provide a sequence of integers we can use
        //This sequence of numbers will start at one at will stop at length
        //With select we will map each value to a new value
        //x => x * number is a lambda function to multiply the number by each number in the sequence
        //ToArray() convert the sequence we create witj Enumerable into an array of doubles as requested.
        return Enumerable.Range(1, length).Select(x => x * number).ToArray();

    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>

    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Check if the amount is 0
        //Declare a variable to hold the amount
        int n = amount;
        //If amount is 0 or the list count, then we do not have to rotate any element in the list
        if (n == 0 || n == data.Count)
        {
            return;
        }
        //Get the new list holding the part of the list we want to rotate
        //Use the GetRange(index, count) method
        List<int> rotated = data.GetRange(data.Count - n, n);
        //Add it to the beginning of the list using the InsertRange(index, list or array) method
        data.InsertRange(0,rotated);
        //Remove it from the end of the list using the RemoveRange(index, count) method
        data.RemoveRange(data.Count - n, n);
        //we do not return anything here because is a void method.
    }
}
