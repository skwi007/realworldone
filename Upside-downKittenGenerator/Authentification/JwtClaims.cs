using System.Security.Claims;
using Upside_downKittenGenerator.Dto;

namespace Upside_downKittenGenerator.Authentification
{
    public static class JwtClaims
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userToken, Guid NameIdentifier)
        {
            IEnumerable<Claim> claims = new Claim[] {
                new Claim("Id", userToken.Id.ToString()),
                    new Claim(ClaimTypes.Name, userToken.Name),
                    new Claim(ClaimTypes.Email, userToken.Email),
                    new Claim(ClaimTypes.NameIdentifier, NameIdentifier.ToString()),
                    new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddHours(2).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };
            return claims;
        }
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return userAccounts.GetClaims(Id);
        }
    }
}
