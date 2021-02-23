using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class WithinTheLast18MonthsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Was the most recent monitoring visit within the last 18 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WithinTheLast18MonthsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public NotEligiblePage SelectYesMonitoringVisitInLast18MonthsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new NotEligiblePage(_context);
        }
        public ApplicationOverviewPage SelectNoForMonitoringVisitInLast18MonthsAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
