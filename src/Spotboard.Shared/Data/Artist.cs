using Newtonsoft.Json;

namespace Spotboard.Shared.Data;

public class Artist
{
    [JsonProperty("name")]
    public string? Name { get; set; }
}
