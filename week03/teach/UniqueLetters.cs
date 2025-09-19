public static class UniqueLetters
{
    public static void Run()
    {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string

        var test4 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLettersSet(test4));

        var test5 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLettersSet(test5));

        var test6 = "";
        Console.WriteLine(AreUniqueLettersSet(test6)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text)
    {
        // TODO Problem 1 - Replace the O(n^2) algorithm to use sets and O(n) efficiency
        for (var i = 0; i < text.Length; ++i)
        {
            for (var j = 0; j < text.Length; ++j)
            {
                // Don't want to compare to yourself ... that will always result in a match
                if (i != j && text[i] == text[j])
                    return false;
            }
        }

        return true;
    }

    private static bool AreUniqueLettersSet(string text)
    {
        //Initialize a new HashSet
        var lettersSet = new HashSet<char>();
        //Iterate over the string
        foreach (var letter in text)
        {
            //If we add the letter to the set we return true
            //Howeber since we are using ! we return false
            //And we skip the clause inside the if statement
            //Example "abcda"
            //1. a is added -> true -> !true -> false -> return true
            //2. b is added -> true -> !true -> false -> return true
            //3. c is added -> true -> !true -> false -> return true
            //4. d is added -> true -> !true -> false -> return true
            //5. a is already in the Set -> false -> !false-> true -> return false
            if (!lettersSet.Add(letter))
            {
                return false;
            }
        }
        //We return true each time we add an element
        //To the Set
        return true;
    }
}