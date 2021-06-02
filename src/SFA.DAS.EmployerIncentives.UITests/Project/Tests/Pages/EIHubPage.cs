using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIHubPage : EIBasePage
    {
        protected override string PageTitle => "Hire a new apprentice payment";

        #region Locators
        private readonly ScenarioContext _context;
        private By ApplyLink => By.LinkText("Apply for the hire a new apprentice payment");
        private By ViewApplicationsLink => By.LinkText("View applications");
        private By ChangeBankDetailsLink => By.LinkText("Change organisation and finance details");
        #endregion

        public EIHubPage(ScenarioContext context) : base(context) => _context = context;

        public EIApplyPage ClickApplyLinkOnEIHubPage()
        {
            formCompletionHelper.Click(ApplyLink);
            return new EIApplyPage(_context);
        }

        public ViewApplicationsPage NavigateToEIViewApplicationsPage()
        {
            formCompletionHelper.Click(ViewApplicationsLink);
            return new ViewApplicationsPage(_context);
        }

        public ViewApplicationsShutterPage NavigateToEIViewApplicationsShutterPage()
        {
            formCompletionHelper.Click(ViewApplicationsLink);
            return new ViewApplicationsShutterPage(_context);
        }

        public ChangeBankDetailsPage NavigateToChangeBankDetailsPage()
        {
            formCompletionHelper.Click(ChangeBankDetailsLink);
            return new ChangeBankDetailsPage(_context);
        }
    }
}
