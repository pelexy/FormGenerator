using Modules.Form;

namespace Modules.FormApplication.Models
{
    public class ApplicationQuestion
    {
        public QuestionType Type { get; set; }
        public string QuestionText { get; set; }
        public bool IsRequired { get; set; }

        public IEnumerable<string> UserAnswers { get; set; }
        public IEnumerable<string> Options { get; set; }

        public bool IsPersonalInfo { get; set; }
    }
}