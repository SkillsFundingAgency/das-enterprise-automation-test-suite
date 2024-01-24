using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class DetailsUpdatedPage : RegistrationBasePage
    {
        protected override string PageTitle => "Details updated";

        #region Locators
        protected override By PageHeader => By.CssSelector(".das-notification__heading");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");
        private static By GoToHomePageRadioButton => By.CssSelector("input[value='homepage']");
        #endregion

        public DetailsUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();

        public HomePage SelectGoToHomePageOptionAndContinueInDetailsUpdatedPage()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(GoToHomePageRadioButton));
            Continue();
            return new HomePage(context);
        }
    }
}