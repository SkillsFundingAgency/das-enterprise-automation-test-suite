using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.Http
{
    public static class ClaimsHelper
    {
        public static List<Claim> GetServiceAccountClaims()
        {
            var claims = new List<Claim>
        {
            CreateSubClaim(),
            CreateServiceAccountClaim(),
            CreateExpiryClaim()
        };

            return claims;
        }

        private static Claim CreateExpiryClaim()
        {
            long unixTime = ((DateTimeOffset)DateTime.UtcNow.AddMinutes(5)).ToUnixTimeSeconds();
            return new Claim("exp", unixTime.ToString());
        }

        private static Claim CreateSubClaim()
        {
            return new Claim("sub", "service-account-id");
        }

        private static Claim CreateServiceAccountClaim()
        {
            return new Claim("serviceAccount", "system-acceptance-tests");
        }

        private static Claim CreateClaim<T>(this T user, Expression<Func<T, string?>> expression)
        {
            var value = expression.Compile().Invoke(user);
            return new Claim(GetJsonPropertyName<T, string>(expression), value ?? string.Empty);
        }

        private static string GetJsonPropertyName<T, TValueType>(Expression<Func<T, TValueType?>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression must be a member expression");
            }

            var objectPropertyName = memberExpression.Member.Name;

            var property = typeof(T).GetProperty(objectPropertyName);
            var attribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();
            return attribute?.Name;
        }
    }
}
