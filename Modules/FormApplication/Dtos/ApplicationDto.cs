namespace Modules.FormApplication.Dtos
{
    public class ApplicationDto
    {
        public string UserId { get; set; }


        public List<ApplicationQuestionDto> ApplicationQuestions { get; set; }
    }
}