using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection_YourTransfers : HomePageFinancesSection
    {
        public HomePageFinancesSection_YourTransfers(ScenarioContext context) : base(context) { }

        private static By HomeButton => By.CssSelector("#navigation > li:nth-child(1) > a");
        public ManageTransferMatchingPage NavigateToTransferMatchingPage()
        {
            formCompletionHelper.Click(YourTransfersLink);
            return new ManageTransferMatchingPage(context);
        }

        public AccountHomePage NavigateToAccountHomePage()
        {
            formCompletionHelper.Click(HomeButton);
            return new AccountHomePage(context);
        }
    }
}
