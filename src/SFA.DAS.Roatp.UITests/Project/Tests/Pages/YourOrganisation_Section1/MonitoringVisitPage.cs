using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class MonitoringVisitPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation had a monitoring visit for apprenticeships in further education and skills?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public MonitoringVisitPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectNoForMonitoringVisitAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new ApplicationOverviewPage(_context);

        }
    }
}
