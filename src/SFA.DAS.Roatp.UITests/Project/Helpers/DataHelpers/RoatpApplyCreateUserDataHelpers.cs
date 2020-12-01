using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers
{
    public class RoatpApplyCreateUserDataHelpers
    {
        public RoatpApplyCreateUserDataHelpers()
        {

        }
        public RoatpApplyCreateUserDataHelpers(RoatpConfig config)
        {
            GivenName = "Test";
            FamilyName = "CreateAccount";
            CreateAccountEmail = $"{GivenName}.{FamilyName}@mailinator.com";
            Password = config.ApplyPassword;
        }

        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string CreateAccountEmail { get; set; }
        public string Password { get; set; }

        public void UpdateData(RoatpApplyCreateUserDataHelpers data)
        {
            GivenName = data.GivenName;
            var familyname = $"{data.FamilyName}";
            FamilyName = familyname;
            CreateAccountEmail = $"{data.GivenName}{familyname}@digital.education.gov.uk";
        }
    }
}
