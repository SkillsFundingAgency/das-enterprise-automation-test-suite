using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmTrainingProviderPermissionsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm permissions";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        protected static By SelectYesConfirmChange => By.Id("confirmation-yes");

        public ConfirmTrainingProviderPermissionsPage(ScenarioContext context) : base(context) => VerifyPage();

        public PermissionsUpdatedPage ConfirmTrainingProviderPermissions()
        {
            Continue();
            return new PermissionsUpdatedPage(context);
        }

        public PermissionsUpdatedPage ConfirmYesTrainingProviderPermissions()
        {
            javaScriptHelper.ClickElement(SelectYesConfirmChange);
            Continue();
            return new PermissionsUpdatedPage(context);
        }

        public HomePage ConfirmProviderLeadRegistrationPermissions()
        {
            Continue();
            return new HomePage(context);
        }
    }
}