using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers
{
    public class RoatpApplyCreateUserDataHelpers
    {
        // This parameterless constructor is also used to create instance from a specflow table
        public RoatpApplyCreateUserDataHelpers()
        {
            var randomPersonNameHelper = new RandomPersonNameHelper();

            GivenName = randomPersonNameHelper.FirstName;
            FamilyName = $"{randomPersonNameHelper.LastName}+{DateTime.UtcNow.ToSeconds()}";
            CreateAccountEmail = $"{GivenName}.{FamilyName}@mailinator.com";
            Password = new Guid().ToString();
        }

        public string GivenName { get; private set; }
        public string FamilyName { get; private set; }
        public string CreateAccountEmail { get; private set; }
        public string Password { get; private set; }

        public void UpdateData(RoatpApplyCreateUserDataHelpers data)
        {
            GivenName = data.GivenName;

            FamilyName = $"{data.FamilyName}";

            CreateAccountEmail = $"{GivenName}{FamilyName}@digital.education.gov.uk";
        }
    }
}
