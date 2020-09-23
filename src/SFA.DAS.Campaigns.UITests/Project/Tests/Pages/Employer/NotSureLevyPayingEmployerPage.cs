using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class NotSureLevyPayingEmployerPage: EmployerBasePage
    {
        protected override string PageTitle => "Page not found";

        public NotSureLevyPayingEmployerPage(ScenarioContext context) :base(context) 
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}