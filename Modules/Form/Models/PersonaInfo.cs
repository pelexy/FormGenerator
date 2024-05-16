using FormBuilder.Modules.Core.Models;

namespace Modules.Form.Models
{
    public class PersonaInfo : BaseEntity
    {


        public string FieldName { get; set; }
        public bool IsHidden { get; set; }

        public bool IsInternal { get; set; }

    }

}