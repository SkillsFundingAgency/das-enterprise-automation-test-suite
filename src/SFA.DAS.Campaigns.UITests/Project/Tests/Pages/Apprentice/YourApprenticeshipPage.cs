using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class YourApprenticeshipPage : ApprenticeBasePage
    {
        protected override string PageTitle => "YOUR APPRENTICESHIP";

        public YourApprenticeshipPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "WHAT TO BRING, AND OTHER USEFUL INFO");
            pageInteractionHelper.VerifyText(Heading2, "MEET YOUR NEW TEAM");
            pageInteractionHelper.VerifyText(Heading3, "WHAT COMES AFTER MY APPRENTICESHIP?");
        }
    }
}
