using Modules.Form.Models;

namespace Modules.Form.Dto
{
    public class ReadProgrammeDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string TenantId { get; set; }
        public string Description { get; set; }
        public List<ReadQuestionDto> Questions { get; set; }
        public List<PersonaInfo> PersonalInfos { get; set; }
    }
}