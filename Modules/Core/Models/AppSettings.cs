namespace FormBuilder.Modules.Core.Models
{
    public class AppSettings
    {
        public Secret? Secret { get; set; }
    }

    public class Secret
    {
        public string? JWTSecret { get; set; }
    }
}
