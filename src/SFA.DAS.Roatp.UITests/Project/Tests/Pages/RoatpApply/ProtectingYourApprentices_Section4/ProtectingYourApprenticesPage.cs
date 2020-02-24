using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class ProtectingYourApprenticesPage : RoatpApplyBasePage
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
