using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Helpers
{
    public class ManagingStandardsDataHelpers
    {
        public ManagingStandardsDataHelpers()
        {
            Website = $"www.company.co.uk";
            ContactWebsite = $"www.companycontact.co.uk";
            ContactNumber = RandomDataGenerator.GenerateRandomAlphanumericString(12);
            EmailAddress = $"ManagingStandardstest.demo@digital.education.gov.uk";
        }
        public string EmailAddress { get; }
        public string Website { get; }
        public string ContactWebsite { get; }
        public string ContactNumber { get; }
    }
}
