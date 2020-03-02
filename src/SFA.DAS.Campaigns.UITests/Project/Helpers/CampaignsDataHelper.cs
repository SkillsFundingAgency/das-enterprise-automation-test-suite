using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class CampaignsDataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public CampaignsDataHelper(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            Firstname = _randomDataGenerator.GenerateRandomAlphabeticString(6);
            Lastname = _randomDataGenerator.GenerateRandomAlphabeticString(9);
            FullName = $"{Firstname} {Lastname}";
            Email = $"{Firstname}.{Lastname}@example.com";
        }

        public string FullName { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Email { get; }
    }
}
