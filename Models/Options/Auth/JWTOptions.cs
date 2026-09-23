namespace Models.Options.Auth
{
    public sealed class JWTOptions
    {
        public const string JWT = "JWT";

        public string? ValidIssuer { get; set; }

        public bool? IncludeTokenOnFailedValidation { get; set; }

        public bool? ValidateIssuerSigningKey { get; set; }

        public string? SigningKey { get; set; }

        public bool? ValidateLifetime { get; set; }

        public bool? ValidateAudience { get; set; }

        public string? ValidAudience { get; set; }

        public bool? RequireSignedTokens { get; set; }

        public bool? RequireExpirationTime { get; set; }

        public bool? RequireAudience { get; set; }
    }
}
