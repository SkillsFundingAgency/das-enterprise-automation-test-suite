using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ConfirmTrusteesPage : RoatpBasePage
    {
        protected override string PageTitle => "Confirm your organisation's trustees";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmTrusteesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TrusteesDOBPage ConfirmTrusteesAndContinue()
        {
            Continue();
            return new TrusteesDOBPage(_context);
        }
    }
}


