using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class ManageCloseVacancyPage : BasePage
    {
        protected override string PageTitle => $"Vacancy VAC{_vacRef} - '{_vacancyTitle}' has been closed.";

        protected override By PageHeader => By.CssSelector(".info-summary");

        #region Helpers and Context
        private readonly string _vacRef;
        private readonly string _vacancyTitle;
        #endregion

        public ManageCloseVacancyPage(ScenarioContext context) : base(context)
        {
            _vacancyTitle = context.Get<RAAV2EmployerDataHelper>().VacancyTitle;
            _vacRef = context.Get<ObjectContext>().GetVacancyReference();
            VerifyPage();
        }
    }
}
