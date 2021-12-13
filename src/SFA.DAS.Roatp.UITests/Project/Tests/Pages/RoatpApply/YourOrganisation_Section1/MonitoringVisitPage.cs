using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class MonitoringVisitPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation had a monitoring visit for apprenticeships in further education and skills?";

        public MonitoringVisitPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage SelectNoForMonitoringVisitAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new ApplicationOverviewPage(context);
        }
        public TwoConsecutiveMonitoringVisitsPage SelectYesForMonitoringVisitAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new TwoConsecutiveMonitoringVisitsPage(context);
        }
      }
    }
