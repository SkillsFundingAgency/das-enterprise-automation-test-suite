using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class FinancePage(ScenarioContext context, bool navigate = false) : InterimFinanceHomePage(context, navigate)
    {
        private static By TransferLink => By.LinkText("Transfers");

        public TransfersPage OpenTransfers()
        {
            formCompletionHelper.ClickElement(TransferLink);
            return new TransfersPage(context);
        }
    }
}