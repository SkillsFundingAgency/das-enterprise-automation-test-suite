using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class PreparingAndMonitoringPage : EmployerBasePage
    {
        protected override string PageTitle => "Page not found";

        public PreparingAndMonitoringPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}

