using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CreateLoginDetailsPage : CreatePasswordBasePage
    {
        protected override string PageTitle => "Create login details";
        private static By EmailAddress => By.Id("Email");
        private static By ConfirmEmail => By.Id("ConfirmEmail");

        public CreateLoginDetailsPage(ScenarioContext context) : base(context) => VerifyPage(PrivacyLinkInTheBody);

        public CreateMyApprenticeshipAccountPage EnterDetailsOnCreateLoginDetailsPageAndContinue()
        {
            EnterEmailAndConfirmEmail();
            formCompletionHelper.EnterText(Password, validPassword);
            formCompletionHelper.EnterText(ConfirmPassword, validPassword);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Save and continue");
            return new CreateMyApprenticeshipAccountPage(context);
        }

        public CreateLoginDetailsPage EnterEmailAndConfirmEmail()
        {
            var email = objectContext.GetApprenticeEmail();
            formCompletionHelper.EnterText(EmailAddress, email);
            formCompletionHelper.EnterText(ConfirmEmail, email);
            return this;
        }
    }
}
