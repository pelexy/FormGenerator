namespace Modules.Form.Dto
{
    public class ReadQuestionDto
    {
        public object Type { get; set; }
        public bool IsHidden { get; set; }
        public string QuestionText { get; set; }
        public IEnumerable<string> Options { get; set; }
    }
}