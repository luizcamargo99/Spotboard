using Newtonsoft.Json;

namespace Spotboard.Data
{
    public class TopItemsResponse
    {
        [JsonProperty("items")]
        public IList<Item>? Items { get; set; }
    }
}
