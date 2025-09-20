using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        //Initialize a set to store unique words.
        //We are only storing the one of the matching pairs.
        //When we find a match (e.g. "am" and "ma") then we add the pair
        //To the list we declared below.
        HashSet<string> wordsSet = new HashSet<string>();
        //Initialize a List to store the pairs of matching words
        List<string> result = new List<string>();
        //Iterate over the array of words
        foreach (string word in words)
        {
            //If we have a word with same letters, we skip it.
            if (word[0] == word[1]) continue;
            //We reverse the string
            string reversed = string.Concat(word[1], word[0]);
            //If the set contains the reversed string
            //It means we found a matching word
            //And we add it to the list with its pair
            //e.g. "am" & "ma"
            if (wordsSet.Contains(reversed))
            {
                string pair = word + " & " + reversed;
                result.Add(pair);
            }
            else
            {
                //If the reversed string is not found
                //We add the word to the set
                wordsSet.Add(word);
            }
        }
        //We return an array of matching pairs of words.
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        //Initialize a dictionary to store the degree information
        var degrees = new Dictionary<string, int>();
        //Iterate over each text line
        foreach (var line in File.ReadLines(filename))
        {
            //Separate each part of the text line by ","
            var fields = line.Split(",");
            //Get the degree summary found on the 4th column
            string degree = fields[3];
            //Check if the degree is already in the dictionary
            if (degrees.ContainsKey(degree))
            {
                //If already exists we increment the count by 1
                degrees[degree]++;
            }
            else
            {
                //If it did not exists in the dictionary
                //We add the degree name and the count = 1
                degrees.Add(degree, 1);
            }

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    /// 
    public static bool IsAnagram(string word1, string word2)
    {
        //We check if the words are not empty strings
        if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
        {
            return false;
        }

        //Remove spaces and convert all letters to lower case
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // Check if the words have the same length
        //If different lengths then they are not anagrams
        if (word1.Length != word2.Length)
        {
            return false;
        }
        //Initialize a dictionary to store the letter and count
        var letters = new Dictionary<char, int>();

        // Count letters in word1
        foreach (char letter in word1)
        {
            //If letter is in the dictionary
            //Increment count by 1
            if (letters.ContainsKey(letter))
            {
                letters[letter]++;
            }
            else
            {
                //If letter not in dictionary
                //Add key and count = 1
                letters.Add(letter, 1);
            }
        }

        // Subtract letters/count if found in word2
        foreach (char letter in word2)
        {
            //If the letter is not in the dictionary
            //That means it is a letter is not in word1
            //Then they are not anagrams
            if (!letters.ContainsKey(letter))
            {
                return false;
            }
            //Substract count for an especifc letter
            letters[letter]--;
            //If count for an specific letter is 0
            //We remove the key
            if (letters[letter] == 0)
            {
                letters.Remove(letter);
            }
        }

        // If the dictionary is empty the words are anagrams
        return letters.Count == 0;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        //Check if no data is returned
        if (featureCollection?.Features == null || featureCollection.Features.Length == 0)
        {
            return Array.Empty<string>();
        }

        // Create the array of results
        return featureCollection.Features
            .Where(f => f.Properties != null && f.Properties.Place != null && f.Properties.Mag.HasValue)
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag.Value}")
            .ToArray();
    }
}

