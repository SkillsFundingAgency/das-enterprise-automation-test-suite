using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class YourTransactionsPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Your transactions";

        public YourTransactionsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
