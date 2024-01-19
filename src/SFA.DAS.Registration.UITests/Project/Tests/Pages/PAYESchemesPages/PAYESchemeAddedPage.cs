using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class PAYESchemeAddedPage : RegistrationBasePage
    {
        protected override string PageTitle => $"{_paye} has been added";

        protected override string AccessibilityPageTitle => "PAYE scheme added page";

        #region Locators
        protected override By PageHeader => By.CssSelector(".das-notification__heading");
        protected override By ContinueButton => By.CssSelector("button#accept");

        private static By AddAnotherPAYEScheme => By.Id("choice1");

        private static By ContinueAccountSetupRadioButton => By.Id("choice3");
        #endregion

        private readonly string _paye;

        public PAYESchemeAddedPage(ScenarioContext context, string paye) : base(context)
        {
            _paye = paye;

            VerifyPage();
        }

        public UsingYourGovtGatewayDetailsPage SelectAddAnotherPAYEScheme()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(AddAnotherPAYEScheme));
            Continue();
            return new UsingYourGovtGatewayDetailsPage(context);
        }

        public HomePage SelectContinueAccountSetupInPAYESchemeAddedPage()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(ContinueAccountSetupRadioButton));
            Continue();
            return new HomePage(context);
        }
    }
}
