namespace Modules.Form.Dto
{
    public class UpdateProgrammeDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string TenantId { get; set; }
        public string Description { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public List<PersonalnfoDto> PersonalInfos { get; set; }
    }
}