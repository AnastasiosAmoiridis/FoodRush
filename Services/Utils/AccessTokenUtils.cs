using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Models.Entities.Auth;
using Models.Options.Auth;
using Services.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

internal class AccessTokenUtils
{
    private readonly AuthOptions _authOptions;

    private readonly TokenValidationParameters _tokenValidationParameters;

    public AccessTokenUtils(AuthOptions options)
    {
        _authOptions = options;

        _tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.JWT.SigningKey)),

            ValidateIssuer = true,
            ValidIssuer = _authOptions.JWT.ValidIssuer,

            ValidateAudience = true,
            ValidAudience = _authOptions.Token.Audience,

            ValidateLifetime = false, // ignore expiration
            ClockSkew = TimeSpan.Zero
        };
    }

    public JwtSecurityToken ParseAccessToken(string token)
    {
        JwtSecurityTokenHandler handeler = new JwtSecurityTokenHandler();

        JwtSecurityToken jwtToken = handeler.ReadJwtToken(token);

        return jwtToken;
    }

    public bool IsAccessTokenValid(string token)
    {
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        try
        {

            handler.ValidateToken(token, _tokenValidationParameters, out SecurityToken validatedToken);


            return validatedToken is JwtSecurityToken;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public AccessTokenWithRawDto GenerateAccessTokenForUser(FoodRushIdentityUser user)
    {
        SymmetricSecurityKey signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.JWT.SigningKey));

        SigningCredentials credentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);


        List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _authOptions.Token.Issuer,
            audience: _authOptions.Token.Audience,
            claims: claims,
            notBefore: null,
            expires: DateTime.UtcNow.AddMinutes(_authOptions.Token.AccessTokenExpirationMinutes),
            signingCredentials: credentials
        );

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string stringToken = handler.WriteToken(token);

        return new AccessTokenWithRawDto { Token = stringToken, AccessToken = token };
    }

}