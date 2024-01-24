using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangeYourUserDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Change your user details";

        private static By FirstNameInput => By.CssSelector($"#FirstName");
        private static By LastNameInput => By.CssSelector($"#LastName");
        protected override By ContinueButton => By.CssSelector("button.govuk-button");

        public ChangeYourUserDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public ConfirmYourUserDetailsPage EnterName()
        {
            formCompletionHelper.EnterText(FirstNameInput, registrationDataHelper.FirstName);
            formCompletionHelper.EnterText(LastNameInput, registrationDataHelper.LastName);
            Continue();
            return new ConfirmYourUserDetailsPage(context);
        }

    }
}
