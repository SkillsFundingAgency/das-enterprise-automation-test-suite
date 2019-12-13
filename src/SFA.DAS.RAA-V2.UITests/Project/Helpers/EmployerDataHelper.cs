using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.RAA_V2.UITests.Project.Helpers
{
    public class EmployerDataHelper : RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;

        public EmployerDataHelper(RandomDataGenerator randomDataGenerator, VacancyTitleDatahelper vacancyTitleDatahelper) : base(randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            _vacancyTitleDatahelper = vacancyTitleDatahelper;
            EmployerTradingName = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerDescription = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerReason = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerWebsiteUrl = WebsiteUrl(EmployerTradingName);
            EmployerContactName = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            EmployerEmail = $"{EmployerContactName}@lorem.com";
            VacancyShortDescription = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyOutcome = _randomDataGenerator.GenerateRandomAlphabeticString(22);
            VacancyBriefOverview = _randomDataGenerator.GenerateRandomAlphabeticString(50);
            TrainingDetails = _randomDataGenerator.GenerateRandomAlphabeticString(28);
            WorkkingWeek = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            DesiredQualificationsSubject = _randomDataGenerator.GenerateRandomAlphabeticString(8);
            OptionalMessage = _randomDataGenerator.GenerateRandomAlphabeticString(30);
        }

        public string VacancyTitle => $"{_vacancyTitleDatahelper.VacancyTitle} apprenticeship";

        public string TrainingTitle => AvailableTraining.RandomOrDefault();

        public string EmployerTradingName { get; }

        public string EmployerDescription { get; }

        public string EmployerReason { get; }
        
        public string EmployerWebsiteUrl { get; }
        
        public string EmployerContactName { get; }

        public string EmployerContactNumber => "07777777777";

        public string EmployerEmail { get; }

        public string VacancyShortDescription { get; }

        public string VacancyOutcome { get; }

        public string TrainingDetails { get; }

        public string WorkkingWeek { get; }

        public DateTime VacancyClosing { get; }

        public DateTime VacancyStart { get; }

        public string VacancyBriefOverview { get; }

        public string DesiredQualificationsSubject { get; }

        public string DesiredQualificationsGrade => "A Level";

        public string NumberOfVacancy => "2" ;

        public string OptionalMessage { get; }

        private string WebsiteUrl(string url) => $"https://www.{url}.com";

        private List<string> AvailableTraining => new List<string> 
        { 
            "Agriculture: Agriculture, Level 3 (A level)",
            "Construction Building: Maintenance Operations, Level 2 (GCSE)",
            "Business to Business Sales Professional (degree), Level 6 (Degree with honours)",
            "Aerospace engineer, Level 6 (Degree with honours)",
            "Software Development Technician, Level 3 (A level)",
            "Software tester, Level 4 (Higher national certificate)",
            "Lifting Technician, Level 2 (GCSE)",
            "Legal Services: Property, Level 3 (A level)"
        };
    }
}