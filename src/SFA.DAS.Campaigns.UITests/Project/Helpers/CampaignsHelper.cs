using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class CampaignsHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public CampaignsHelper(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
        }

        public string EmployerFirstname(string x) => $"{x}{_randomDataGenerator.GenerateRandomAlphabeticString(6)}";

        public string EmployerLastname(string x) => $"{x}{_randomDataGenerator.GenerateRandomAlphabeticString(6)}";
    }
}
