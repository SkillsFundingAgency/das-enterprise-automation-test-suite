using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAODataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public EPAODataHelper (RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            GetCurrentDay = DateTime.Now.Day;
            GetCurrentMonth = DateTime.Now.Month;
            GetCurrentYear = DateTime.Now.Year;
            Get9DigitRandomNumber = _randomDataGenerator.GenerateRandomNumber(9);
            Get10DigitRandomNumber = _randomDataGenerator.GenerateRandomNumber(10);
            GetRandomEmail = GetDateTimeValue() + "@mailinator.com";
            GetRandomWebsiteAddress = "http://www.TEST_" + GetDateTimeValue() + ".com";
            GetRandomAddressLine1 = _randomDataGenerator.GenerateRandomNumber(3);
        }

        public int GetCurrentDay { get; }

        public int GetCurrentMonth { get; }

        public int GetCurrentYear { get; }

        public string Get9DigitRandomNumber { get; }

        public string Get10DigitRandomNumber { get; }

        public string GetRandomEmail { get; }

        public string GetRandomWebsiteAddress { get; }

        public string GetRandomAddressLine1 { get; }

        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMMyyyy_HHmmss").ToUpper(); 
    }
}
