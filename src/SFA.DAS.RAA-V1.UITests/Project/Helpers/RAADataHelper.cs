using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class RAADataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly RegexHelper _regexHelper;

        public RAADataHelper(RandomDataGenerator randomDataGenerator, RegexHelper regexHelper)
        {
            var datetime = System.DateTime.Now;
            _randomDataGenerator = randomDataGenerator;
            _regexHelper = regexHelper;
            EmployerDescription = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerReason = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerBody = _randomDataGenerator.GenerateRandomAlphabeticString(25);
            EmployerWebsiteUrl = WebsiteUrl(EmployerDescription);
            VacancyTitle = $"{_randomDataGenerator.GenerateRandomAlphabeticString(10)}_{datetime.ToString("ddMMMyyyy_HHmmss")}";
            VacancyShortDescription = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyDescription = _randomDataGenerator.GenerateRandomAlphabeticString(50);
            VacancyWebsiteUrl = WebsiteUrl(VacancyShortDescription);
            ApplicationProcess = _randomDataGenerator.GenerateRandomAlphabeticString(40);
            TrainingDetails = _randomDataGenerator.GenerateRandomAlphabeticString(28);
            TrainingContactName = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            TrainingEmail = $"{TrainingContactName}@lorem.com";
            WorkkingWeek = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            DesiredSkills = _randomDataGenerator.GenerateRandomAlphabeticString(18);
            PersonalQualities = _randomDataGenerator.GenerateRandomAlphabeticString(20);
            DesiredQualifications = _randomDataGenerator.GenerateRandomAlphabeticString(24);
            FutureProspects = _randomDataGenerator.GenerateRandomAlphabeticString(30);
            ThingsToConsider = _randomDataGenerator.GenerateRandomAlphabeticString(35);
            FirstQuestion = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            SecondQuestion = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            AdditionalLocationInformation = _randomDataGenerator.GenerateRandomAlphabeticString(5);
        }

        public string EmployerErn { get; private set; }

        public IWebElement Employers(List<IWebElement> links)
        {
            var randomEmployer = RandomElement(links).Item2;

            EmployerErn = _regexHelper.GetEmployerERN(randomEmployer.GetAttribute("href"));

            return randomEmployer;
        }

        public IWebElement Address(List<IWebElement> addresses) => RandomElement(addresses).Item2;

        public int CloneVacancy(List<IWebElement> vacancies) => RandomElement(vacancies).Item1;

        public string EmployerDescription { get; }

        public string EmployerReason { get; }

        public string EmployerBody { get; }
        
        public string EmployerWebsiteUrl { get; }

        public string VacancyTitle { get; }

        public string VacancyShortDescription { get; }

        public string VacancyWebsiteUrl { get; }

        public string ApplicationProcess { get; }

        public string TrainingDetails { get; }

        public int RandomCourse => _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(2, 20);

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

        public string SecondQuestion { get; }
        
        public string FirstQuestion { get; }

        public string AdditionalLocationInformation { get;}
        
        public string NumberOfVacancy => "2" ;

        private string WebsiteUrl(string url) => $"https://www.{url}.com";

        private (int,IWebElement) RandomElement(List<IWebElement> elements)
        {
            var randomNumber = _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, elements.Count - 1);

            return (randomNumber, elements[randomNumber]);
        }
    }
}

