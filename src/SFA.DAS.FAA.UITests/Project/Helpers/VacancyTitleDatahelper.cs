using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.FAA.UITests.Project.Helpers
{
    public class VacancyTitleDatahelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public VacancyTitleDatahelper(RandomDataGenerator randomDataGenerator)
        {
            VacancyTitleDate = DateTime.Now;
            VacancyTitleDateElement = VacancyTitleDate.ToString("ddMMMyyyy");
            VacancyTitle = $"{_randomDataGenerator.GenerateRandomAlphabeticString(10)}_{VacancyTitleDateElement}_{VacancyTitleDate.ToString("HHmmssfffff")}";
        }

        public DateTime VacancyTitleDate { get; }

        public string VacancyTitleDateElement { get; }

        public string VacancyTitle { get; }

    }
}