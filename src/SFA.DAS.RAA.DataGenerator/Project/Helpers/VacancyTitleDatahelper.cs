using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.RAA.DataGenerator
{
    public class VacancyTitleDatahelper
    {
        public VacancyTitleDatahelper(RandomDataGenerator randomDataGenerator)
        {
            VacancyTitleDate = DateTime.Now;
            VacancyTitleDateElement = VacancyTitleDate.ToString("ddMMMyyyy");
            VacancyTitle = $"{randomDataGenerator.GenerateRandomAlphabeticString(10)}_{VacancyTitleDateElement}_{VacancyTitleDate.ToString("HHmmssfffff")}";
        }

        public DateTime VacancyTitleDate { get; }

        public string VacancyTitleDateElement { get; }

        public string VacancyTitle { get; }

    }
}