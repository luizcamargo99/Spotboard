using Newtonsoft.Json;

namespace Spotboard.Data
{
    public class Item
    {
        [JsonProperty("artists")]
        public List<Artist>? Artists { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
