using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class WhosInControlCriminalAndComplianceChecksPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Criminal and compliance checks on who's in control of your organisation";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhosInControlCriminalAndComplianceChecksPage(ScenarioContext context) : base(context)
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
