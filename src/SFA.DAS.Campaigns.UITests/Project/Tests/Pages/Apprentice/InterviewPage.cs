using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class InterviewPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Error";

        public InterviewPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
