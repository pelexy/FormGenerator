namespace Modules.FormApplication.Dtos
{
    public class ReadApplicationDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }


        public List<ReadApplicationQuestionDto> ApplicationQuestions { get; set; }
    }
}