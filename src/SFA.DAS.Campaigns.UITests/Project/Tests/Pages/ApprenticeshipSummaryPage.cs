using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ApprenticeshipSummaryPage : CampaingnsBasePage
    {
        protected override string PageTitle => "Apprenticeship summary";

        protected override By PageHeader => By.CssSelector("#vacancy-info .heading-large");

        #region Helpers and Context
        private readonly ObjectContext objectContext;
        #endregion

        private By VacancyTitle => By.CssSelector("#vacancy-title");

        public ApprenticeshipSummaryPage(ScenarioContext context) : base(context) 
        {
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        public void VerifyVacancyTitle() => pageInteractionHelper.GetText(VacancyTitle).ContainsCompareCaseInsensitive(objectContext.GetVacancyTitle());
    }
}
