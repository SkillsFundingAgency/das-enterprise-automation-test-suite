using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplicationSavedPage : EIBasePage
    {
        protected override string PageTitle => "Application saved";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public ApplicationSavedPage(ScenarioContext context) : base(context) => _context = context;

        public ViewApplicationsPage NavigateToViewApplicationsPage()
        {
            formCompletionHelper.ClickLinkByText("View applications");
            return new ViewApplicationsPage(_context);
        }
    }
}
