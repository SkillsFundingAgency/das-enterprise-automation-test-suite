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
            Email = $"TestContact_{RandomEmail}";
            NewOrganisationName = $"New Org {GetRandomAlphabeticString(10)}";
            NewOrganisationLegalName = $"{NewOrganisationName} Legal Name";
            NewOrganisationUkprn = $"99{GetRandomNumber(6)}";
            CompanyNumber = $"76{GetRandomNumber(6)}";
            CharityNumber = $"9{GetRandomNumber(4)}-{GetRandomNumber(2)}";
        }

        public string Standards => "100";

        public string StandardsName => "Transport planning technician";

        public string OrganisationName => "City and Guilds";

        public string OrganisationEpaoId => "EPA0008";

        public string MakeLiveOrganisationEpaoId => "EPA0337";

        public string OrganisationUkprn => "10009931";

        public string BatchSearch => "110";

        public string LearnerUln => "7278214419";

        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; }

        public string PhoneNumber => $"0844455{GetRandomNumber(4)}";

        public DateTime StandardsEffectiveFrom => new DateTime(2015, 08, 01);

        public DateTime OrgStandardsEffectiveFrom => StandardsEffectiveFrom.AddDays(35);

        public string NewOrganisationName { get; }

        public string NewOrganisationLegalName { get; }

        public string NewOrganisationUkprn { get; }

        public string CompanyNumber { get; }

        public string CharityNumber { get; }

        public string StreetAddress1 => "5 Quninton Road";

        public string StreetAddress2 => "Cheylsmore Avuene";

        public string StreetAddress3 => "Warkwickshire";
    }
}
