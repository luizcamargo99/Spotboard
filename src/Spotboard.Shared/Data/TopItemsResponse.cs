using Newtonsoft.Json;

namespace Spotboard.Shared.Data;

public class TopItemsResponse
{
    [JsonProperty("items")]
    public IList<Item>? Items { get; set; }
}
