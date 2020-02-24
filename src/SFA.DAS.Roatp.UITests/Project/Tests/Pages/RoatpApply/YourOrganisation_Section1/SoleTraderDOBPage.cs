using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class SoleTraderDOBPage : RoatpApplyBasePage
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


