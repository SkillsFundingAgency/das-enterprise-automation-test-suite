using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CreateMyApprenticeshipAccountPage(ScenarioContext context) : PersonalDetailsBasePage(context)
    {
        protected override string PageTitle => "Create My apprenticeship account";
        private static By FirstNameError => By.XPath("(//span[@class='govuk-error-message field-validation-error'])[1]");
        private static By LastNameError => By.XPath("(//span[@class='govuk-error-message field-validation-error'])[2]");
        private static By DOBError => By.XPath("(//span[@class='govuk-error-message field-validation-error'])[3]");
        protected override By ContinueButton => By.CssSelector("#identity-assurance-btn");

        public new CreateMyApprenticeshipAccountPage NavigateToChangeYourPersonalDetails()
        {
            NavigateToSettings("Change your personal details");
            return new CreateMyApprenticeshipAccountPage(context);
        }

        public TermsOfUsePage ConfirmIdentityAndGoToTermsOfUsePage()
        {
            EnterValidApprenticeDetails();
            return new TermsOfUsePage(context);
        }

        public CreateMyApprenticeshipAccountPage EnterInvalidData(string firstname, string lastname, int? day, int? month, int? year)
        {
            EnterApprenticeDetails(firstname, lastname, day, month, year);
            return this;
        }

        public new (TermsOfUsePage page, (string firstName, string lastName) name) EnterInValidApprenticeDetails()
        {
            var name = base.EnterInValidApprenticeDetails();
            return (new TermsOfUsePage(context), name);
        }

        public void VerifyErrorSummary()
        {
            pageInteractionHelper.VerifyText(ErrorSummaryTitle, "There is a problem");
            pageInteractionHelper.VerifyText(FirstNameError, "Enter your first name");
            pageInteractionHelper.VerifyText(LastNameError, "Enter your last name");
            pageInteractionHelper.VerifyText(DOBError, "Enter your date of birth");
        }
    }
}
