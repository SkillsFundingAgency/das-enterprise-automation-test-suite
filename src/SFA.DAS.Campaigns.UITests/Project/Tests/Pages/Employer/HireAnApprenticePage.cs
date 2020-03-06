using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class HireAnApprenticePage : EmployerBasePage
    {
        protected override string PageTitle => "HIRE AN APPRENTICE";

        public HireAnApprenticePage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "FINDING THE RIGHT APPRENTICE FOR YOU");
            pageInteractionHelper.VerifyText(Heading2, "HOW TO ASK THE RIGHT QUESTIONS AT INTERVIEW");
        }
    }
}

