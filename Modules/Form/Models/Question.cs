using FormBuilder.Modules.Core.Models;

namespace Modules.Form.Models
{
    public class Question : BaseEntity
    {

        public QuestionType Type { get; set; }
        public string QuestionText { get; set; }
        public bool IsRequired { get; set; }


        public IEnumerable<string> Options { get; set; }
    }
}