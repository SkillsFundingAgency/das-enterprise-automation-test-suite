using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV1DataHelper
    {
        public RAAV1DataHelper()
        {
            EmployerDescription = RandomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerReason = RandomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerBody = RandomDataGenerator.GenerateRandomAlphabeticString(25);
            EmployerWebsiteUrl = WebsiteUrl(EmployerDescription);
            VacancyShortDescription = RandomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyDescription = RandomDataGenerator.GenerateRandomAlphabeticString(50);
            VacancyWebsiteUrl = WebsiteUrl(VacancyShortDescription);
            ApplicationProcess = RandomDataGenerator.GenerateRandomAlphabeticString(40);
            TrainingDetails = RandomDataGenerator.GenerateRandomAlphabeticString(28);
            TrainingContactName = RandomDataGenerator.GenerateRandomAlphabeticString(5);
            TrainingEmail = $"{TrainingContactName}@lorem.com";
            WorkkingWeek = RandomDataGenerator.GenerateRandomAlphabeticString(15);
            FixedWagePerWeek = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(300, 350).ToString();
            CustomMinWagePerWeek = FixedWagePerWeek;
            CustomMaxWagePerWeek = (int.Parse(FixedWagePerWeek) + RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(50, 100)).ToString();
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            NewVacancyClosing = VacancyClosing.AddDays(15);
            NewVacancyStart = NewVacancyClosing.AddDays(15);
            DesiredSkills = RandomDataGenerator.GenerateRandomAlphabeticString(18);
            PersonalQualities = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            DesiredQualifications = RandomDataGenerator.GenerateRandomAlphabeticString(24);
            FutureProspects = RandomDataGenerator.GenerateRandomAlphabeticString(30);
            ThingsToConsider = RandomDataGenerator.GenerateRandomAlphabeticString(35);
            FirstQuestion = RandomDataGenerator.GenerateRandomAlphabeticString(15);
            SecondQuestion = RandomDataGenerator.GenerateRandomAlphabeticString(15);
            AdditionalLocationInformation = RandomDataGenerator.GenerateRandomAlphabeticString(5);
            ShareApplicationEmail = $"{TrainingContactName}@gmail.com";
            OptionalMessage = RandomDataGenerator.GenerateRandomAlphabeticString(30);              
        }

        public string EmployerErn { get; private set; }

        public IWebElement Employers(List<IWebElement> links)
        {
            var randomEmployer = RandomDataGenerator.GetRandomElementFromListOfElements(links);

            EmployerErn = RegexHelper.GetEmployerERN(randomEmployer.GetAttribute("href"));

            return randomEmployer;
        }
                

        public string EmployerDescription { get; }

        public string EmployerReason { get; }

        public string EmployerBody { get; }
        
        public string EmployerWebsiteUrl { get; }

        public string VacancyShortDescription { get; }

        public string VacancyWebsiteUrl { get; }

        public string ApplicationProcess { get; }

        public string TrainingDetails { get; }

        public int RandomNumber => RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(2, 20);

        public string TrainingContactName { get; }

        public string TrainingContactNumber => "07777777777";

        public string TrainingEmail { get; }

        public string WorkkingWeek { get; }

        public string FixedWagePerWeek { get; }

        public string CustomMinWagePerWeek { get; }

        public string CustomMaxWagePerWeek { get; }    

        public DateTime VacancyClosing { get; }

        public DateTime NewVacancyClosing { get; }

        public DateTime NewVacancyStart { get; }

        public DateTime VacancyStart { get; }

        public string VacancyDescription { get; }

        public string DesiredSkills { get;}
        
        public string PersonalQualities { get; }
        
        public string DesiredQualifications { get; }
        
        public string FutureProspects { get; }
        
        public string ThingsToConsider { get; }

        public string SecondQuestion { get; }
        
        public string FirstQuestion { get; }

        public string AdditionalLocationInformation { get;}
        
        public string NumberOfVacancy => "2" ;

        public string ShareApplicationEmail { get; }

        public string OptionalMessage { get; }

        private string WebsiteUrl(string url) => $"https://www.{url}.com";
    }
}