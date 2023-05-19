using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class WhichEmployerAreYouConnectingWithPage : TransfersBasePage
    {
        protected override string PageTitle => "Which employer are you connecting with?";

        protected override By ContinueButton => EnvironmentConfig.IsTestEnvironment ? By.CssSelector("#main-content button.govuk-button[type='submit']") : By.CssSelector(".button");
        private By ReceivingEmployer => By.Id("ReceiverAccountPublicHashedId");

        public WhichEmployerAreYouConnectingWithPage(ScenarioContext context) : base(context) { }

        public ConfirmConnectionDetailsPage ConnectWithReceivingEmployer(string receiverAccountId)
        {
            formCompletionHelper.EnterText(ReceivingEmployer, receiverAccountId);
            Continue();
            return new ConfirmConnectionDetailsPage(context);
        }
    }
}