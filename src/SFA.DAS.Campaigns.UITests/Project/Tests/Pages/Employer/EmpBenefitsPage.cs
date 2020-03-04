using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmpBenefitsPage : EmployerBasePage
    {
        protected override string PageTitle => "BENEFITS TO YOUR ORGANISATION";

        public EmpBenefitsPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "THE BENEFITS TO YOUR ORGANISATION");
        }
    }
}
