using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class SetUpServicePage : ApprenticeBasePage
    {
        protected override string PageTitle => "Page not found";
        private ScenarioContext context;

        public SetUpServicePage(ScenarioContext context):base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}