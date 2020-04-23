using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class TransfersPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Transfers";

        public TransfersPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
