using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class RequestSentConfirmPage(ScenarioContext context) : TransfersBasePage(context)
    {
        protected override string PageTitle => "Request sent";

        protected override By PageHeader => By.CssSelector("#govuk-notification-banner-title");

        protected override By ContinueButton => By.XPath("//button[text()='Continue']");

        private static By GoToHomePageRadioButton => By.CssSelector(".govuk-radios__label");

        public HomePage GoToHomePage()
        {
            formCompletionHelper.SelectRadioOptionByText(GoToHomePageRadioButton, "Go to the homepage");
            Continue();
            return new HomePage(context);
        }
    }
}