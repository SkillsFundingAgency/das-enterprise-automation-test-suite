using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.Http
{
    public static class ServiceBearerTokenProvider
    {
        private const int ExpiryTime = 20;

        public static string GetServiceBearerToken(string? signingKey)
        {
            ValidateSigningKey(signingKey);

            var claims = ClaimsHelper.GetServiceAccountClaims();

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signingKey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.UtcNow.AddMinutes(ExpiryTime)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private static void ValidateSigningKey(string? signingKey)
        {
            if (string.IsNullOrEmpty(signingKey))
            {
                throw new BearerTokenException("Signing key cannot be null or empty");
            }

            const int minimumKeySize = 128;
            if (signingKey.Length * 8 < minimumKeySize)
            {
                // This checks the key is at least 128 bits long, otherwise the token will fail to be generated
                throw new BearerTokenException("Signing key must be at least 128bits in length");
            }
        }
    }
}
