using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAODataHelper : RandomElementHelper
    {
        protected readonly RandomDataGenerator randomDataGenerator;

        public EPAODataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            this.randomDataGenerator = randomDataGenerator;
            GetCurrentDay = DateTime.Now.Day;
            GetCurrentMonth = DateTime.Now.Month;
            GetCurrentYear = DateTime.Now.Year;
            GetRandomEmail = GetDateTimeValue() + "@mailinator.com";
            GetRandomWebsiteAddress = "http://www.TEST_" + GetDateTimeValue() + ".com";
        }

        public int GetCurrentDay { get; }
        public int GetCurrentMonth { get; }
        public int GetCurrentYear { get; }
        public string GetRandomEmail { get; }
        public string GetRandomWebsiteAddress { get; }
        public string GetTownName => "Coventry";
        public string GetCountyName => "Warwick";
        public string GetPostCode => "CV1 2WT";
        public string InvalidOrgNameWithAlphabets => "asfasfasdfasdf";
        public string InvalidOrgNameWithNumbers => "54678900";
        public string InvalidOrgNameWithAWord => "EPA01";

        public string GetRandomNumber(int length) => randomDataGenerator.GenerateRandomNumber(length);

        public string GetRandomAlphabeticString(int length) => randomDataGenerator.GenerateRandomAlphabeticString(length);

        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMMyyyy_HHmmss").ToUpper();
    }
}
