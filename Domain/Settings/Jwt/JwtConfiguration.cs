namespace Domain.Settings.Jwt
{
    public class JwtConfiguration
    {
        public string SecretKey { get; init; }
        public string Encryptkey { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public int ExpirationMinutes { get; init; }


    }
}
