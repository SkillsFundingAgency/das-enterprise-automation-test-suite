using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class ConnectionConfirmedPage : TransfersBasePage
    {
        protected override string PageTitle => "Connection confirmed";

        protected override By PageHeader => By.Id("govuk-notification-banner-title");

        protected override By ContinueButton => By.XPath("//button[text()='Continue']");

        private By GoToHomePageRadioButton => By.CssSelector(".govuk-radios__label");

        public ConnectionConfirmedPage(ScenarioContext context) : base(context) { }

        public HomePage GoToHomePage()
        {
            formCompletionHelper.SelectRadioOptionByText(GoToHomePageRadioButton, "Go to the homepage");
            Continue();
            return new HomePage(context);
        }
    }
}