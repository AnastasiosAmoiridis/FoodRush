namespace Models.Options.Auth
{
    public sealed class AuthOptions
    {
        public const string Auth = "Auth";

        public JWTOptions JWT { get; set; }

        public TokenOptions Token { get; set; }
    }
}
