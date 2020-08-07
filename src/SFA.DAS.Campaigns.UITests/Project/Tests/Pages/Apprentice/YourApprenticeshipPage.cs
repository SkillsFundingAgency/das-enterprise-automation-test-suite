using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class YourApprenticeshipPage : ApprenticeBasePage
    {
        protected override string PageTitle => "STARTING YOUR APPRENTICESHIP";

        public YourApprenticeshipPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading2, "TRAINING PROVIDERS");
        }
    }
}
