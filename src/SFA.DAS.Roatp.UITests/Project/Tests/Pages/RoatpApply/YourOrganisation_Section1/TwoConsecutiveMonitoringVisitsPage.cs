using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class TwoConsecutiveMonitoringVisitsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation had 2 consecutive monitoring visits with the grade 'insufficient progress'?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TwoConsecutiveMonitoringVisitsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WithinTheLast18MonthsPage SelectYesForTwoConsecutiveMonitoringVisitAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new WithinTheLast18MonthsPage(_context);
        }
    }
}
