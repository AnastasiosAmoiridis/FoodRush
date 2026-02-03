namespace Models.Entities.Auth
{
    public class RefreshToken
    {
        public Guid Id { get; set; }

        public required string Token { get; set; }

        public DateTime Expires { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Revoked { get; set; }

        public string? ReasonRevoked { get; set; }   
    }
}
