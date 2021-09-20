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
        private readonly ScenarioContext _context;

        public CreateLoginDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public CreateMyApprenticeshipAccountPage EnterDetailsOnCreateLoginDetailsPageAndContinue()
        {
            var email = objectContext.GetApprenticeEmail();
            formCompletionHelper.EnterText(EmailAddress, email);
            formCompletionHelper.EnterText(ConfirmEmail, email);
            formCompletionHelper.EnterText(Password, _validPassword);
            formCompletionHelper.EnterText(ConfirmPassword, _validPassword);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Save and continue");
            return new CreateMyApprenticeshipAccountPage(_context);
        }
    }
}
