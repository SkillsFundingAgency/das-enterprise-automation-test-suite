using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class FinancePage : InterimFinanceHomePage
    {
        private static By TransferLink => By.LinkText("Transfers");

        public FinancePage(ScenarioContext context, bool navigate = false) : base(context, navigate) { }

        public TransfersPage OpenTransfers()
        {
            formCompletionHelper.ClickElement(TransferLink);
            return new TransfersPage(context);
        }
    }
}