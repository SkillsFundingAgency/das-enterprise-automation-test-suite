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
            Get9DigitRandomULN = _randomDataGenerator.GenerateRandomNumber(9);
            Get10DigitRandomULN = _randomDataGenerator.GenerateRandomNumber(10);
        }

        public int GetCurrentDay { get; }

        public int GetCurrentMonth { get; }

        public int GetCurrentYear { get; }

        public string Get9DigitRandomULN { get; }

        public string Get10DigitRandomULN { get; }
    }
}
