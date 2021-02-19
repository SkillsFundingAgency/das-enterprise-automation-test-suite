using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplicationCompletePage : EIBasePage
    {
        protected override string PageTitle => "Application complete";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public ApplicationCompletePage(ScenarioContext context) : base(context) => _context = context;

        public HomePage ReturnToAccountHomePage()
        {
            formCompletionHelper.ClickLinkByText("Return to account home");
            return new HomePage(_context);
        }
    }
}
