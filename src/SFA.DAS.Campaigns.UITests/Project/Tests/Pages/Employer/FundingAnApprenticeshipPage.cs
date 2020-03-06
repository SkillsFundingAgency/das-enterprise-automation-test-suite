using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class FundingAnApprenticeshipPage : EmployerBasePage
    {
        protected override string PageTitle => "HOW MUCH IS IT GOING TO COST?";

        public FundingAnApprenticeshipPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "HOW MUCH WILL IT COST ME?");
            pageInteractionHelper.VerifyText(Heading2, "IF YOU DON'T NEED TO PAY THE APPRENTICESHIP LEVY");
            pageInteractionHelper.VerifyText(Heading3, "ADDITIONAL PAYMENTS FROM THE GOVERNMENT");
        }
    }
}
