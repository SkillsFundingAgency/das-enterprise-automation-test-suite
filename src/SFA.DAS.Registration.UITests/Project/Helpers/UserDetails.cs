using System;
using SFA.DAS.FrameworkHelpers;

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
        public static UserDetails Valid_User => new("valid", "UserFirstName", "UserLastName", "UserEmail", "AccountPassword123", "AccountPassword123", "Confirm your identity", "true");
        public static UserDetails Invalid_User => new("invalid", "UserFirstName", "UserLastName", "UserEmail", "AccountPassword123", "NotSamePassword", "Set up as a user", "false");

        public string Testcase { get; init; }
        public string FName { get; init; }
        public string LName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Confirmpassword { get; init; }
        public string Output { get; init; }
        public string CheckDb { get; init; }

        public UserDetails(string testcase, string fName, string lName, string email, string password, string confirmpassword, string output, string checkDb)
        {
            Testcase = TrimAnySpace(testcase);
            FName = TrimAnySpace(fName);
            LName = TrimAnySpace(lName);
            Email = $"{TrimAnySpace(email)}_POC_{DateTime.Now.ToSeconds()}@{new EmailDomainHelper(Array.Empty<string>()).GetEmailDomain()}";
            Password = TrimAnySpace(password);
            Confirmpassword = TrimAnySpace(confirmpassword);
            Output = TrimAnySpace(output);
            CheckDb = TrimAnySpace(checkDb);
        }

        private string TrimAnySpace(string x) => x.Trim();

        public override string ToString() => $"Testcase :'{Testcase}',FName: '{FName}',LName : '{LName}',Email : '{Email}'" +
        $",Password : '{Password}',Confirmpassword : '{Confirmpassword}',Output : '{Output}', Checkdb : '{CheckDb}'";
    }
}
