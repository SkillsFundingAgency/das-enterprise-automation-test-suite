using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.RAA.DataGenerator
{
    public class VacancyTitleDatahelper
    {
        public VacancyTitleDatahelper(bool isCloneVacancy)
        {
            VacancyTitleDate = DateTime.Now;

            VacancyTitleDateElement = VacancyTitleDate.ToString("ddMMMyyyy");

            var part1 = isCloneVacancy ? $"Clone {RandomDataGenerator.GenerateRandomAlphabeticString(4)}" : $"{RandomDataGenerator.GenerateRandomAlphabeticString(10)}";

            SetVacancyTitile($"{part1}_{VacancyTitleDateElement}_{VacancyTitleDate:HHmmssfffff}");
        }

        public DateTime VacancyTitleDate { get; }

        public string VacancyTitleDateElement { get; }

        public string VacancyTitle { get; private set; }

        public void SetVacancyTitile(string vacancyTitle) => VacancyTitle = vacancyTitle;

    }
}