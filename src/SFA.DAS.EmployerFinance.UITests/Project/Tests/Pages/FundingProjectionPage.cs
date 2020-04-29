using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class FundingProjectionPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Funding projection";

        public FundingProjectionPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
