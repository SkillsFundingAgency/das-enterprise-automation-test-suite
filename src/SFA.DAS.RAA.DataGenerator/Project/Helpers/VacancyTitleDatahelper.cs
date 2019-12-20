using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.RAA.DataGenerator
{
    public class VacancyTitleDatahelper
    {
        public VacancyTitleDatahelper(RandomDataGenerator randomDataGenerator, bool isCloneVacancy)
        {
            VacancyTitleDate = DateTime.Now;
            VacancyTitleDateElement = VacancyTitleDate.ToString("ddMMMyyyy");
            var part1 = isCloneVacancy ? $"Clone {randomDataGenerator.GenerateRandomAlphabeticString(4)}" : $"{randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            VacancyTitle = $"{part1}_{VacancyTitleDateElement}_{VacancyTitleDate.ToString("HHmmssfffff")}";
        }

        public DateTime VacancyTitleDate { get; }

        public string VacancyTitleDateElement { get; }

        public string VacancyTitle { get; }

    }
}