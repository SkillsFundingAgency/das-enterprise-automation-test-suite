using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class ChooseTheRightApprenticeshipPage : EmployerBasePage
    {
        protected override string PageTitle => "THE RIGHT APPRENTICESHIP";

        public ChooseTheRightApprenticeshipPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "WHICH APPRENTICESHIP IS RIGHT FOR MY ORGANISATION?");
            pageInteractionHelper.VerifyText(Heading2, "I WANT TO FIND AN APPRENTICE FOR MY ORGANISATION");
            pageInteractionHelper.VerifyText(Heading3, "TYPES OF APPRENTICESHIPS");
        }
    }
}

