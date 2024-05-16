using Newtonsoft.Json;

namespace FormBuilder.Modules.Core.Models
{
    public class BaseEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("createdat")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonProperty("lastupdated")]
        public DateTime? LastUpdated { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
