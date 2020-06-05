using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV1DataHelper : RandomElementHelper
    {
        private readonly RegexHelper _regexHelper;

        public RAAV1DataHelper(RandomDataGenerator randomDataGenerator, RegexHelper regexHelper) : base(randomDataGenerator)
        {
            _regexHelper = regexHelper;
            EmployerDescription = this.randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerReason = this.randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerBody = this.randomDataGenerator.GenerateRandomAlphabeticString(25);
            EmployerWebsiteUrl = WebsiteUrl(EmployerDescription);
            VacancyShortDescription = this.randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyDescription = this.randomDataGenerator.GenerateRandomAlphabeticString(50);
            VacancyWebsiteUrl = WebsiteUrl(VacancyShortDescription);
            ApplicationProcess = this.randomDataGenerator.GenerateRandomAlphabeticString(40);
            TrainingDetails = this.randomDataGenerator.GenerateRandomAlphabeticString(28);
            TrainingContactName = this.randomDataGenerator.GenerateRandomAlphabeticString(5);
            TrainingEmail = $"{TrainingContactName}@lorem.com";
            WorkkingWeek = this.randomDataGenerator.GenerateRandomAlphabeticString(15);
            FixedWagePerWeek = this.randomDataGenerator.GenerateRandomNumberBetweenTwoValues(300, 350).ToString();
            CustomMinWagePerWeek = FixedWagePerWeek;
            CustomMaxWagePerWeek = (int.Parse(FixedWagePerWeek) + this.randomDataGenerator.GenerateRandomNumberBetweenTwoValues(50, 100)).ToString();
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            NewVacancyClosing = VacancyClosing.AddDays(15);
            NewVacancyStart = NewVacancyClosing.AddDays(15);
            DesiredSkills = this.randomDataGenerator.GenerateRandomAlphabeticString(18);
            PersonalQualities = this.randomDataGenerator.GenerateRandomAlphabeticString(20);
            DesiredQualifications = this.randomDataGenerator.GenerateRandomAlphabeticString(24);
            FutureProspects = this.randomDataGenerator.GenerateRandomAlphabeticString(30);
            ThingsToConsider = this.randomDataGenerator.GenerateRandomAlphabeticString(35);
            FirstQuestion = this.randomDataGenerator.GenerateRandomAlphabeticString(15);
            SecondQuestion = this.randomDataGenerator.GenerateRandomAlphabeticString(15);
            AdditionalLocationInformation = this.randomDataGenerator.GenerateRandomAlphabeticString(5);
            ShareApplicationEmail = $"{TrainingContactName}@gmail.com";
            OptionalMessage = this.randomDataGenerator.GenerateRandomAlphabeticString(30);              
        }

        public string EmployerErn { get; private set; }

        public IWebElement Employers(List<IWebElement> links)
        {
            var randomEmployer = randomDataGenerator.GetRandomElementFromListOfElements(links);

            EmployerErn = _regexHelper.GetEmployerERN(randomEmployer.GetAttribute("href"));

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

        public int RandomNumber => randomDataGenerator.GenerateRandomNumberBetweenTwoValues(2, 20);

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

        public string TrainingStandard => EnvironmentConfig.IsTestEnvironment ? "Accountancy Taxation Professional" : "Accountancy / Taxation Professional";
    }
}