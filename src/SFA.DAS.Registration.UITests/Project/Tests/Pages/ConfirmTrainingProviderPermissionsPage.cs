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

        public EmployerAccountCreatedPage ConfirmAndGoToEmployerAccountCreatedPage()
        {
            var SelectConfirmButton = By.XPath("//*[@id=\"main-content\"]/div/div/form/div/button");

            javaScriptHelper.ClickElement(SelectConfirmButton);
            Continue();
            return new EmployerAccountCreatedPage(context);
        }
    }
}