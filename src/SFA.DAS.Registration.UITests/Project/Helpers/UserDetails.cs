using System;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class GetUserDetailsHelper
    {
        public static UserDetails GetUserDetails(string testcase)
        {
            return true switch
            {
                bool _ when testcase == "valid" => UserDetails.Valid_User,
                bool _ when testcase == "invalid" => UserDetails.Invalid_User,
                _ => throw new Exception($"no testcase found for {testcase}")
            };
        }
    }

    public record UserDetails
    {

        public static UserDetails Valid_User => new("valid", "UserFirstName", "UserLastName", "UserEmail", "AccountPassword123", "AccountPassword123");
        public static UserDetails Invalid_User => new("invalid", "UserFirstName", "UserLastName", "UserEmail", "AccountPassword123", "NotSamePassword");

        public string Testcase { get; init; }
        public string FName { get; init; }
        public string LName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Confirmpassword { get; init; }

        public UserDetails(string testcase, string fName, string lName, string email, string password, string confirmpassword)
        {
            Testcase = testcase;
            FName = fName;
            LName = lName;
            Email = $"{RegexHelper.TrimAnySpace(email)}_{DateTime.Now.ToSeconds()}@{new EmailDomainHelper(Array.Empty<string>()).GetEmailDomain()}";
            Password = password;
            Confirmpassword = confirmpassword;
        }
    }
}
