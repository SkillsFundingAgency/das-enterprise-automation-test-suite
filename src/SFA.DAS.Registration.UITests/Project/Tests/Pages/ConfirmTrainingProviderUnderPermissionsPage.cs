using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmTrainingProviderUnderPermissionsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm training provider";

        private static By SelectYesConfirm => By.XPath("//fieldset[@class='govuk-fieldset']//input[@automation-id='choice-1']");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        public ConfirmTrainingProviderUnderPermissionsPage(ScenarioContext context) : base(context)  { }

        internal YouVeSuccessfullyAddedProviderPage ConfirmTrainingProvider()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SelectYesConfirm);
            Continue();
            return new YouVeSuccessfullyAddedProviderPage(context);
        }
    }
}