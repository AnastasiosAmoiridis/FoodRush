namespace Models.Options.Auth
{
    public sealed class TokenOptions
    {
        public const string Token = "Token";

        public string? Issuer { get; set; }

        public string? Audience { get; set; }
    }
}

