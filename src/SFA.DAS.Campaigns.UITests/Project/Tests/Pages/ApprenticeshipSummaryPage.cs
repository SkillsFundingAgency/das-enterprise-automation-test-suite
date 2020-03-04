using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ApprenticeshipSummaryPage : CampaingnsPage
    {
        protected override string PageTitle => "Apprenticeship summary";

        protected override By PageHeader => By.CssSelector("#vacancy-info .heading-large");

        private By VacancyTitle => By.CssSelector("#vacancy-title");

        public ApprenticeshipSummaryPage(ScenarioContext context) : base(context) => VerifyPage();

        public void VerifyVacancyTitle() => pageInteractionHelper.GetText(VacancyTitle).ContainsCompareCaseInsensitive(objectContext.GetVacancyTitle());
    }
}
