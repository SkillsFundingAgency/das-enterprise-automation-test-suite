using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages
{
    public class StubAddYourUserDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Add your user details";

        private static By FirstNameInput => By.CssSelector($"#FirstName");
        private static By LastNameInput => By.CssSelector($"#LastName");
        protected override By ContinueButton => By.CssSelector("button.govuk-button");

        public StubAddYourUserDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public AddAPAYESchemePage EnterNameAndGoToAddAPAYESchemePage()
        {
            EnterNameAndContinue();
            return new AddAPAYESchemePage(context);
        }

        public InvitationsPage EnterNameAndGoToInvitationsPage()
        {
            EnterNameAndContinue();
            return new InvitationsPage(context);
        }

        private void EnterNameAndContinue()
        {
            formCompletionHelper.EnterText(FirstNameInput, registrationDataHelper.FirstName);
            formCompletionHelper.EnterText(LastNameInput, registrationDataHelper.LastName);
            Continue();
        }
    }
}
