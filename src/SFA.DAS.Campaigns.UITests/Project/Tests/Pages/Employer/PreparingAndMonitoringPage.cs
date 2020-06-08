using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class PreparingAndMonitoringPage : EmployerBasePage
    {
        protected override string PageTitle => "PREPARING AND MONITORING";

        public PreparingAndMonitoringPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "PREPARING");
            pageInteractionHelper.VerifyText(Heading2, "MONITORING");
        }
    }
}

