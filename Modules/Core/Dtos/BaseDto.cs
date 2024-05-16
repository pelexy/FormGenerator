namespace Modules.Core.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdated { get; set; }
    }
}