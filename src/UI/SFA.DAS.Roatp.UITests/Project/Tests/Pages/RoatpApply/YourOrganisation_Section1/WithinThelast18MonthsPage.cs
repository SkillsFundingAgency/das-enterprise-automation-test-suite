using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class WithinTheLast18MonthsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Was the most recent monitoring visit within the last 18 months?";

        public WithinTheLast18MonthsPage(ScenarioContext context) : base(context) => VerifyPage();

        public NotEligiblePage SelectYesMonitoringVisitInLast18MonthsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new NotEligiblePage(context);
        }
        public ApplicationOverviewPage SelectNoForMonitoringVisitInLast18MonthsAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
