using System;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class GetUserDetailsHelper
    {
        public static UserDetails GetUserDetails(string userdetails)
        {
            return true switch
            {
                bool _ when userdetails == "valid" => UserDetails.Valid_User,
                bool _ when userdetails == "invalid" => UserDetails.Invalid_User,
                _ => new UserDetails(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
            };
        }
    }

    public record UserDetails
    {

        public static UserDetails Valid_User => new("Valid", "User", "ValidUser", "AccountPassword123", "AccountPassword123");
        public static UserDetails Invalid_User => new("Invalid", "User", "InvalidUser", "AccountPassword123", "NotSamePassword");

        public string FName { get; init; }
        public string LName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Confirmpassword { get; init; }

        public UserDetails(string fName, string lName, string email, string password, string confirmpassword)
        {
            FName = fName;
            LName = lName;
            Email = $"{email}_{DateTime.Now.ToSeconds()}@{new EmailDomainHelper(Array.Empty<string>()).GetEmailDomain()}";
            Password = password;
            Confirmpassword = confirmpassword;
        }
    }
}
