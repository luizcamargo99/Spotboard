using Newtonsoft.Json;

namespace Spotboard.Data
{
    public class UserProfile
    {
        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }
    }
}
