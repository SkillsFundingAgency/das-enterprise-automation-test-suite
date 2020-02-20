using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class InLineWithInstituteForApprenticeshipPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Do you understand that your organisation must develop and deliver apprenticeship training in line with the Institute for Apprenticeships and Technical Education's 'quality statement'?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InLineWithInstituteForApprenticeshipPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesForInLineWithInstituteForApprenticeshipAndContinue()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}