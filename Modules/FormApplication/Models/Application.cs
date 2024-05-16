using FormBuilder.Modules.Core.Models;
using Newtonsoft.Json;

namespace Modules.FormApplication.Models
{
    public class Application : BaseEntity
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("applicationQuestions")]
        public List<ApplicationQuestion> ApplicationQuestions { get; set; }
    }
}