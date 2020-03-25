using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ItechartProj.Services.Services
{
    public class TokenService
    {
        public static object CreateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                AuthOptions.ISSUER,
                AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public static List<Claim> GetClaims(string token)
        {
            if (token == null) return null;
            var claims = new List<Claim>();
            var handler = new JwtSecurityTokenHandler();
            var readToken = handler.ReadToken(token) as JwtSecurityToken;

            if (readToken != null)
                foreach (var item in readToken.Claims)
                    claims.Add(item);

            return claims;
        }

        public static bool IsExpired(string token)
        {
            var validationParameters =
                new TokenValidationParameters
                {
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidIssuer = AuthOptions.ISSUER,
                    IssuerSigningKeys = new[] {new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthOptions.KEY))}
                };

            var validate = new JwtSecurityTokenHandler();
            try
            {
                validate.ValidateToken(token, validationParameters, out _);
            }
            catch (Exception)
            {
                return true;
            }

            return false;
        }

        public static List<Claim> VerifyToken(string token)
        {
            if (!IsExpired(token))
            {
                var tokenClaims = GetClaims(token);
                if (tokenClaims != null)
                    return tokenClaims;
            }

            return null;
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}