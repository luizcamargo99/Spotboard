using Newtonsoft.Json;

namespace Spotboard.Data
{
    public class Artist
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
