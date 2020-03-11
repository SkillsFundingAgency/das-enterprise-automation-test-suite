using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageCloseVacancyPage : BasePage
    {
        protected override string PageTitle => $"Vacancy VAC{_vacRef} - '{_vacancyTitle}' has been closed.";

        protected override By PageHeader => By.CssSelector(".info-summary");

        private By RecruitmentLInk => By.LinkText("Recruitment");

        #region Helpers and Context
        private readonly string _vacRef;
        private readonly string _vacancyTitle;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public ManageCloseVacancyPage(ScenarioContext context) : base(context)
        {
            _vacancyTitle = context.Get<RAAV2DataHelper>().VacancyTitle;
            _vacRef = context.Get<ObjectContext>().GetVacancyReference();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public void GoToRecruitmentHomePage()
        {
            _formCompletionHelper.Click(RecruitmentLInk); 
        }
    }
}
