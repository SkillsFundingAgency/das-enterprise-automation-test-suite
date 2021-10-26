using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CreateMyApprenticeshipAccountPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Create My apprenticeship account";
        private By FirstName => By.CssSelector("input#FirstName");
        private By LastName => By.CssSelector("input#LastName");
        private By DateOfBirth_Day => By.CssSelector("input#DateOfBirth_Day");
        private By DateOfBirth_Month => By.CssSelector("input#DateOfBirth_Month");
        private By DateOfBirth_Year => By.CssSelector("input#DateOfBirth_Year");
        private By ErrorSummaryTitle => By.Id("error-summary-title");
        private By LastNameError => By.XPath("(//div[@class='govuk-error-message']/ul/li)[1]");
        private By FirstNameError => By.XPath("(//div[@class='govuk-error-message']/ul/li)[2]");
        private By DOBError => By.XPath("(//div[@class='govuk-error-message']/ul/li)[3]");
        protected override By ContinueButton => By.CssSelector("#identity-assurance-btn");

        public CreateMyApprenticeshipAccountPage(ScenarioContext context) : base(context) => _context = context;

        public TermsOfUsePage ConfirmIdentityAndGoToTermsOfUsePage()
        {
            EnterApprenticeDetails(objectContext.GetFirstName(),
                objectContext.GetLastName(),
                objectContext.GetDateOfBirth().Day,
                objectContext.GetDateOfBirth().Month,
                objectContext.GetDateOfBirth().Year);

            return new TermsOfUsePage(_context);
        }

        public CreateMyApprenticeshipAccountPage InvalidData(string firstname, string lastname, int? day, int? month, int? year)
        {
            EnterApprenticeDetails(firstname, lastname, day, month, year);
            return this;
        }

        public void VerifyErrorSummary()
        {
            pageInteractionHelper.VerifyText(ErrorSummaryTitle, "There is a problem");
            pageInteractionHelper.VerifyText(LastNameError, "Enter your last name");
            pageInteractionHelper.VerifyText(FirstNameError, "Enter your first name");
            pageInteractionHelper.VerifyText(DOBError, "Enter your date of birth");
        }

        private void EnterApprenticeDetails(string firstname, string lastname, int? day, int? month, int? year)
        {
            formCompletionHelper.EnterText(FirstName, firstname);
            formCompletionHelper.EnterText(LastName, lastname);

            if (day != null)
            {
                formCompletionHelper.EnterText(DateOfBirth_Day, day ?? 0);
            }
            if (month != null)
            {
                formCompletionHelper.EnterText(DateOfBirth_Month, month ?? 0);
            }
            if (year != null)
            {
                formCompletionHelper.EnterText(DateOfBirth_Year, year ?? 0);
            }

            Continue();
        }
    }
}
