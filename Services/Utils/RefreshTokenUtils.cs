using Models.Entities.Auth;
using System.Security.Cryptography;
using System.Text;

internal static class RefreshTokenUtils
{
    public static string GenerateRandomToken(int byteCount = 64)
    {
        byte[] bytes = RandomNumberGenerator.GetBytes(byteCount);

        string token = Convert.ToBase64String(bytes);
        return token;
    }

    public static string HashRefreshToken(string token)
    {
        using HashAlgorithm hashAlgorithm = SHA256.Create();

        byte[] tokenBytes = Encoding.UTF8.GetBytes(token);
        byte[] hashBytes = hashAlgorithm.ComputeHash(tokenBytes);

        // Return hash as Base64 string
        string hash = Convert.ToBase64String(hashBytes);
        return hash;
    }

    public static void MarkRefreshTokenAsReplaced(RefreshToken? activeToken, RefreshToken newToken, string? reason = null)
    {
        if (activeToken != null)
        {
            activeToken.ReplacedByToken = newToken;
            activeToken.ReplacedByTokenId = newToken.Id;
            activeToken.Revoked = DateTime.UtcNow;
            activeToken.ReasonRevoked = reason;
        }
    }

    public static bool IsRefreshTokenValid(RefreshToken? token)
    {
        if (token != null)
        {
            bool hasExpired = DateTime.UtcNow > token.Expires;
            bool isRevoked = token.Revoked != null;

            if (!(hasExpired || isRevoked))
            {
                return true;
            }
        }
        return false;
    }
}
