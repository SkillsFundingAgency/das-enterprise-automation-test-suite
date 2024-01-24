using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class ConnectWithReceivingEmployerPage(ScenarioContext context) : TransfersBasePage(context)
    {
        protected override By PageHeader => By.CssSelector("#main-content");
        protected override string PageTitle => "Connect with a receiving employer";

        private static By ContinueToConnect => By.LinkText("Continue");

        public WhichEmployerAreYouConnectingWithPage ContinueToConnectWithReceiver()
        {
            formCompletionHelper.ClickElement(ContinueToConnect);
            return new WhichEmployerAreYouConnectingWithPage(context);
        }
    }
}