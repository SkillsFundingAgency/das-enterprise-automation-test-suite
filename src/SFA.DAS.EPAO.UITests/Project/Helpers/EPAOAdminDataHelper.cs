using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAOAdminDataHelper : EPAODataHelper
    {
        public EPAOAdminDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator) 
        {
            FirstName = GetRandomAlphabeticString(6);
            LastName = GetRandomAlphabeticString(6);
            Email = $"TestContact_{GetRandomEmail}";
        }

        public string OrganisationName => "City and Guilds";

        public string OrganisationEpaoId => "EPA0008";

        public string OrganisationUkprn => "10009931";

        public string BatchSearch => "110";

        public string LearnerUln => "7278214419";

        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; }

        public string PhoneNumber => $"0844455{GetRandomNumber(4)}";

        public string Standards => "100";

        public DateTime StandardsEffectiveFrom => new DateTime(2015, 08, 01);

        public string StandardsName => "Transport planning technician (100)";

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> options) => randomDataGenerator.GetRandomElementFromListOfElements(options);

    }
}
