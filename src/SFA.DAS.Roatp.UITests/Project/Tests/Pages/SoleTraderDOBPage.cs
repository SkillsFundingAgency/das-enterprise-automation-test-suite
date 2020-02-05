using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class SoleTraderDOBPage : RoatpBasePage
    {
        protected override string PageTitle => "date of birth?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SoleTraderDOBPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}


