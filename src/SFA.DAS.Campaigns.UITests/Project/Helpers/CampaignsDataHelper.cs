using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class CampaignsDataHelper : RandomElementHelper
    {
        public CampaignsDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            Firstname = randomDataGenerator.GenerateRandomAlphabeticString(6);
            Lastname = randomDataGenerator.GenerateRandomAlphabeticString(9);
            FullName = $"{Firstname} {Lastname}";
            Email = $"{Firstname}.{Lastname}@example.com";
            CourseId = new List<string>();
            ProviderId = new List<string>();
        }

        public string FullName { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Email { get; }

        public string Route => "Care services";

        public string Distance => "40 miles";

        public string Postcode => "CV1 1DD";

        public string ProviderPostcode => "CV1 4HS";

        public List<string> Postcodes = new List<string> { "SW1V 3LP", "M1 4WB", "G1 1YU", "EH2 4AD", "NN1 1SR", "CV1 4AH", "BS1 3LE", "SN1 1LF", "YO1 7DT", "LS1 4AG", "TW3 3JW" };

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> options) => base.GetRandomElementFromListOfElements(options);

        public List<string> CourseId { get; internal set; }

        public List<string> ProviderId { get; internal set; }
    }
}
