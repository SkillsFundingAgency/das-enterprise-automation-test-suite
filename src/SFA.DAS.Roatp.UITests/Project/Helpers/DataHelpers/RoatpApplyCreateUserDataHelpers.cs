using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers
{
    public class RoatpApplyCreateUserDataHelpers
    {
        public RoatpApplyCreateUserDataHelpers()
        {
            GivenName = "Test";
            FamilyName = "CreateAccount";
            CreateAccountEmail = $"{GivenName}.{FamilyName}@mailinator.com";
            Password = "RoatpAutomation123";
        }

        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string CreateAccountEmail { get; set; }
        public string Password { get; set; }

        public void UpdateData(RoatpApplyCreateUserDataHelpers data)
        {
            GivenName = data.GivenName;
            var familyname = $"{data.FamilyName}{DateTime.Now:ddMMMyyyy_HHmmss}";
            FamilyName = familyname;
            CreateAccountEmail = $"{data.GivenName}{familyname}@digital.education.gov.uk";
        }
    }
}
