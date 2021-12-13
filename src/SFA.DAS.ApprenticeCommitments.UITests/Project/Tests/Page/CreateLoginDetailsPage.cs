using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.ApprenticeCommitments.APITests.Project;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CreateLoginDetailsPage : CreatePasswordBasePage
    {
        protected override string PageTitle => "Create login details";
        private By EmailAddress => By.Id("Email");
        private By ConfirmEmail => By.Id("ConfirmEmail");
        
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
