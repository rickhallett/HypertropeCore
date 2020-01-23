namespace HypertropeCore.Options
{
    public class JwtSettings
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Expires { get; set; }
        
        public string SecretKey { get; set; }
    }
}