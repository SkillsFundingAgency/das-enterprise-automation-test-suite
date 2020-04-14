using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class DownloadTransactionsPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Download transactions";

        public DownloadTransactionsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
