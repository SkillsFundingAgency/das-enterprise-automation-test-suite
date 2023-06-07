using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class ConnectWithReceivingEmployerPage : TransfersBasePage
    {
        protected override string PageTitle => "Connect with a receiving employer";

        private By ContinueToConnect => By.LinkText("Continue");

        public ConnectWithReceivingEmployerPage(ScenarioContext context) : base(context) { }

        public WhichEmployerAreYouConnectingWithPage ContinueToConnectWithReceiver()
        {
            formCompletionHelper.ClickElement(ContinueToConnect);
            return new WhichEmployerAreYouConnectingWithPage(context);
        }
    }
}