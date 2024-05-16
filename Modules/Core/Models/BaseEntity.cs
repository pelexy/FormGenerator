namespace Ripple.API.Modules.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdated { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
