using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Upside_downKittenGenerator.Dto;

namespace Upside_downKittenGenerator.Authentification
{
    public static class Token
    {
        public static UserTokens GenenarateTokenkey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var UserToken = new UserTokens();
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid GuidId = Guid.Empty;
                DateTime expireTime = DateTime.UtcNow.AddHours(2);
                UserToken.Validaty = expireTime.TimeOfDay;
                var JWToken = new JwtSecurityToken(issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: model.GetClaims(out GuidId),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256));
                UserToken.Token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                UserToken.Name = model.Name;
                UserToken.Email = model.Email;
                UserToken.Id = model.Id;
                UserToken.GuidId = GuidId;
                UserToken.ExpiredTime = expireTime;
                return UserToken;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
