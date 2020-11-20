using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers
{
    public class RoatpApplyCreateUserDataHelpers
    {
        public RoatpApplyCreateUserDataHelpers()
        {

        }

        public RoatpApplyCreateUserDataHelpers(RandomDataGenerator randomDataGenerator)
        {
            GivenName = "Test";
            FamilyName = "CreateAccount";
            CreateAccountEmail = $"{GivenName}.{FamilyName}@mailinator.com";
            Password = randomDataGenerator.GenerateRandomPassword(2, 2, 2, 2);
        }


        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string CreateAccountEmail { get; set; }
        public string Password { get; set; }
    }
}
