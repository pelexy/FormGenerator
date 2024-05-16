using FormBuilder.Modules.Core.Models;
using Newtonsoft.Json;

namespace Modules.Form.Models
{

    public class Programme : BaseEntity
    {
        [JsonProperty("title")]

        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("tenantid")]
        public string TenantId { get; set; }
        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }
        [JsonProperty("personalinfos")]
        public List<PersonaInfo> PersonalInfos { get; set; }

    }
}