namespace Modules.Form.Dto
{
    public class QuestionDto
    {
        public QuestionType Type { get; set; }  // e.g., Paragraph, Numeric, Date, etc.
        public string QuestionText { get; set; }
        public bool IsRequired { get; set; }
        public IEnumerable<string> Options { get; set; }  // For dropdowns or multiple choice questions
    }
}