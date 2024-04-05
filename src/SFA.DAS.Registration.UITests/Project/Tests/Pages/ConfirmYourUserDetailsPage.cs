using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmYourUserDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm your user details";
        private static By ChangeLink => By.CssSelector("a.govuk-link[href*='/User/add-user-details']");

        public ConfirmYourUserDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public YouVeSuccessfullyAddedUserDetailsPage ConfirmNameAndContinue(bool updated = false)
        {
            Continue();
            return new YouVeSuccessfullyAddedUserDetailsPage(context, updated);
        }

        public StubAddYourUserDetailsPage ClickChange()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeLink));
            return new StubAddYourUserDetailsPage(context);
        }
    }
}
