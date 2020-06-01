using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class InterviewPage : ApprenticeBasePage
    {
        protected override string PageTitle => "INTERVIEW";

        public InterviewPage(ScenarioContext context) : base(context, false) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "THE INTERVIEW PROCESS");
            pageInteractionHelper.VerifyText(Heading2, "BEFORE YOUR INTERVIEW");
            pageInteractionHelper.VerifyText(Heading3, "DAY OF THE INTERVIEW");
        }
    }
}
