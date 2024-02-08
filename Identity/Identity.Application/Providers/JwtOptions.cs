namespace Identity.Application.Providers
{
    public class JwtOptions
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public int JwtExpiresInDays { get; set; }
        public string ClientUrl { get; set; }
    }
}
