using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerGuidePage : EmployerBasePage
    {
        private ScenarioContext context;
        protected override string PageTitle => "Page not found";
        public EmployerGuidePage(ScenarioContext context): base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}