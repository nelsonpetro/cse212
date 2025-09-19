/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        Dictionary<string, int> players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row


        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            //We check if the Map already contains the element
            //If it is already in the Map we sum up the points
            if (players.ContainsKey(playerId))
            {
                //Sum up points for an specific player
                players[playerId] += points;
            }
            else
            {
                //If player is not in the map
                //Add it to the map
                players.Add(playerId, points);
            }


        }

        //Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        //Convert the Map into an Array
        var topPlayers = players.ToArray();
        //Sort the array in descendent order
        Array.Sort(topPlayers, (p1, p2) => p2.Value.CompareTo(p1.Value));
        //Display the first 10 players in the Array.
        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine(topPlayers[i]);
        }

        // foreach (var player in topPlayers)
        // {
        //     Console.WriteLine(player);
        // }
    }
}