using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeHubPage : ApprenticeBasePage
    {
        protected override string PageTitle => "APPRENTICES";

        protected override By PageHeader => PageHeaderTag;

        protected By SetUpService => By.CssSelector("a[href*='create-account']"); 

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeHubPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToApprenticeshipHubPage());

        public SetUpServicePage NavigateToSetUpServiceAccountPage()
        {
            formCompletionHelper.ClickElement(SetUpService);
            return new SetUpServicePage(_context);
        }
    }
}
