using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Dapper;
using SFA.DAS.EAS.AutomatedApiTests.Database;

namespace SFA.DAS.EAS.AutomatedApiTests.Helpers
{
    public static class UserHelper
    {
        public static Guid CreateUser(string usersConnectionString, string profilesConnectionString, string username, string email, string password)
        {
            var profile = GetFirstProfile(profilesConnectionString);

            var salt = new byte[profile.SaltLength];
            var securePassword = SecurePassword(password, salt, profile);

            using (var connection = new SqlConnection(usersConnectionString))
            {
                return WriteUser(connection, username, securePassword, salt, profile, email);
            }
        }

        public static void TeardownUser(Guid userId, string usersConnectionString)
        {
            using (var connection = new SqlConnection(usersConnectionString))
            {
                DeleteUser(connection, userId);
            }
        }

        public static void ClearExistingTestUsers(string email, string usersConnectionString)
        {
            using (var connection = new SqlConnection(usersConnectionString))
            {
                DeleteUsersByEmail(connection, email);
            }
        }

        private static PasswordProfile GetFirstProfile(string profilesConnectionString)
        {
            using (var connection = new SqlConnection(profilesConnectionString))
            {
                var resultset = connection.Query<PasswordProfile>("SELECT TOP 1 * FROM PasswordProfile");
                return resultset.SingleOrDefault();
            }
        }

        private static string SecurePassword(string plainText, byte[] salt, PasswordProfile profile)
        {
            var saltedPassword = salt.Concat(Encoding.Unicode.GetBytes(plainText)).ToArray();

            var hasher = new HMACSHA256(Convert.FromBase64String(profile.Key));
            var hash = hasher.ComputeHash(saltedPassword);

            var pbkdf2 = new Rfc2898DeriveBytes(Convert.ToBase64String(hash), salt, profile.WorkFactor);
            var password = pbkdf2.GetBytes(profile.StorageLength);

            return Convert.ToBase64String(password);
        }

        private static Guid WriteUser(SqlConnection connection, string username, string password, byte[] salt, PasswordProfile profile, string email)
        {
            var firstName = username;
            var lastName = username;
            var id = Guid.NewGuid();

            var user = new User
            {
                Id = id.ToString(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Salt = Convert.ToBase64String(salt),
                PasswordProfileId = profile.Id,
                IsActive = true,
                FailedLoginAttempts = 0,
                IsLocked = false
            };

            connection.Execute("CreateUser @Id, @FirstName, @LastName, @Email, @Password, @Salt, @PasswordProfileId, @IsActive, @FailedLoginAttempts, @IsLocked",
                user);

            connection.Execute("CreateHistoricalPassword @UserId, @Password, @Salt, @PasswordProfileId, @DateSet",
                new { UserId = user.Id, user.Password, user.Salt, user.PasswordProfileId, DateSet = DateTime.Now });

            return id;
        }

        private static void DeleteUser(SqlConnection connection, Guid userId)
        {
            connection.Execute("DeleteUser @Id", new {Id = userId});
        }

        private static void DeleteUsersByEmail(SqlConnection connection, string email)
        {
            var ids = connection.Query<string>("SELECT Id FROM [User] WHERE Email = @Email", new { Email = email });
            foreach (var id in ids)
            {
                connection.Execute("DeleteUser @Id", new { Id = id });
            }
        }
    }
}
