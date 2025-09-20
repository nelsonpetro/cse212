using System.Text.Json.Serialization;
// Classes describing the JSON
public class FeatureCollection
{
    [JsonPropertyName("features")]
    public Feature[] Features { get; set; }
}

public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

public class Properties
{
    [JsonPropertyName("mag")]
    public double? Mag { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }
}