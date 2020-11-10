using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIAccessDeniedPage : EIBasePage
    {
        protected override string PageTitle => "Your account does not have the right access";

        #region Locators
        private readonly ScenarioContext _context;
        private string ReturnToAccountHomeButton => "Return to account home";
        #endregion

        public EIAccessDeniedPage(ScenarioContext context) : base(context) => _context = context;

        public HomePage ReturnToAccountHomePage()
        {
            formCompletionHelper.ClickLinkByText(ReturnToAccountHomeButton);
            return new HomePage(_context);
        }
    }
}
