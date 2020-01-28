using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAODataHelper : RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public EPAODataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            GetCurrentDay = DateTime.Now.Day;
            GetCurrentMonth = DateTime.Now.Month;
            GetCurrentYear = DateTime.Now.Year;
            Get9DigitRandomNumber = _randomDataGenerator.GenerateRandomNumber(9);
            Get10DigitRandomNumber = _randomDataGenerator.GenerateRandomNumber(10);
            GetGivenName = "G" + _randomDataGenerator.GenerateRandomAlphabeticString(10);
            GetFamilyName = "F" + _randomDataGenerator.GenerateRandomAlphabeticString(10);
            GetRandomAddressLine1 = _randomDataGenerator.GenerateRandomNumber(3);
            GetTownName = "Coventry";
            GetCountyName = "Warwick";
            GetPostCode = "CV1 2WT";
            GetRandomEmail = GetDateTimeValue() + "@mailinator.com";
            GetRandomWebsiteAddress = "http://www.TEST_" + GetDateTimeValue() + ".com";
        }

        public int GetCurrentDay { get; }
        public int GetCurrentMonth { get; }
        public int GetCurrentYear { get; }
        public string Get9DigitRandomNumber { get; }
        public string Get10DigitRandomNumber { get; }
        public string GetGivenName { get; }
        public string GetFamilyName { get; }
        public string GetRandomAddressLine1 { get; }
        public string GetTownName { get; }
        public string GetCountyName { get; }
        public string GetPostCode { get; }
        public string GetRandomEmail { get; }
        public string GetRandomWebsiteAddress { get; }

        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMMyyyy_HHmmss").ToUpper();
    }
}
