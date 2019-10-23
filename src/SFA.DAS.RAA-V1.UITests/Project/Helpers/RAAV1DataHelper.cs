using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class RAAV1DataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RAAV1DataHelper(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            EmployerDescription = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerReason = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerBody = _randomDataGenerator.GenerateRandomAlphabeticString(25);
            EmployerWebsiteUrl = WebsiteUrl(EmployerDescription);
            VacancyShortDescription = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            VacancyDescription = _randomDataGenerator.GenerateRandomAlphabeticString(50);
            VacancyWebsiteUrl = WebsiteUrl(VacancyShortDescription);
            ApplicationProcess = _randomDataGenerator.GenerateRandomAlphabeticString(40);
            TrainingDetails = _randomDataGenerator.GenerateRandomAlphabeticString(28);
            TrainingContactName = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            TrainingEmail = $"{TrainingContactName}@lorem.com";
            WorkkingWeek = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyStart = DateTime.Today.AddMonths(1).AddDays(3);
            VacancyClosing = VacancyStart.AddMonths(2).AddDays(3);
            DesiredSkills = _randomDataGenerator.GenerateRandomAlphabeticString(18);
            PersonalQualities = _randomDataGenerator.GenerateRandomAlphabeticString(20);
            DesiredQualifications = _randomDataGenerator.GenerateRandomAlphabeticString(24);
            FutureProspects = _randomDataGenerator.GenerateRandomAlphabeticString(30);
            ThingsToConsider = _randomDataGenerator.GenerateRandomAlphabeticString(35);
        }

        public string EmployerDescription { get; }

        public string EmployerReason { get; }

        public string EmployerBody { get; }
        
        public string EmployerWebsiteUrl { get; }

        public string VacancyShortDescription { get; }

        public string VacancyWebsiteUrl { get; }

        public string ApplicationProcess { get; }

        public string TrainingDetails { get; }

        public string TrainingContactName { get; }

        public string TrainingContactNumber => "07777777777";

        public string TrainingEmail { get; }

        public string WorkkingWeek { get; }

        public DateTime VacancyClosing { get; }

        public DateTime VacancyStart { get; }

        public string VacancyDescription { get; }

        public string DesiredSkills { get;}
        
        public string PersonalQualities { get; }
        
        public string DesiredQualifications { get; }
        
        public string FutureProspects { get; }
        
        public string ThingsToConsider { get; }

        private string WebsiteUrl(string url) => $"https://www.{url}.com";
    }
}

