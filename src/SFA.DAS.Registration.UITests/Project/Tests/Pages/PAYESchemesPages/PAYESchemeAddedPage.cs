using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class PAYESchemeAddedPage : RegistrationBasePage
    {
        protected override string PageTitle => $"{objectContext.GetGatewayPaye(1)} has been added";

        protected override string AccessibilityPageTitle => "PAYE scheme added page";

        #region Locators
        protected override By PageHeader => By.CssSelector(".das-notification__heading");
        protected override By ContinueButton => By.CssSelector("button#accept");
        private static By ContinueAccountSetupRadioButton => By.Id("choice3");
        #endregion

        public PAYESchemeAddedPage(ScenarioContext context) : base(context) => VerifyPage();

        public HomePage SelectContinueAccountSetupInPAYESchemeAddedPage()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(ContinueAccountSetupRadioButton));
            Continue();
            return new HomePage(context);
        }
    }
}
