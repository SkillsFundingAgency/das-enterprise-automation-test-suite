using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.ProtectingYourApprentices_Section4
{
    public class ActingAsASubContractorPage : RoatpBasePage
    {
        protected override string PageTitle => "When acting as a subcontractor, will your organisation follow its lead provider's policies and plans?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ActingAsASubContractorPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYes()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
