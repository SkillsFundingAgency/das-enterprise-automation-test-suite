using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ProtectingYourApprenticesPage : RoatpBasePage
    {
        protected override string PageTitle => "Protecting your apprentices";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProtectingYourApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage ClickSaveAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
