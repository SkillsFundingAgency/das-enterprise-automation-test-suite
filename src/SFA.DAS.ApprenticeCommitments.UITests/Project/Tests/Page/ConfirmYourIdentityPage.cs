using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourIdentityPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Confirm your identity";

        private readonly ScenarioContext _context;

        private By FirstName => By.CssSelector("input#FirstName");
        private By LastName => By.CssSelector("input#LastName");
        private By DateOfBirth_Day => By.CssSelector("input#DateOfBirth_Day");
        private By DateOfBirth_Month => By.CssSelector("input#DateOfBirth_Month");
        private By DateOfBirth_Year => By.CssSelector("input#DateOfBirth_Year");
        private By NationalInsuranceNumber => By.CssSelector("input#NationalInsuranceNumber");
        private By ErrorSummary => By.CssSelector(".govuk-error-summary");

        protected override By ContinueButton => By.CssSelector("#identity-assurance-btn");

        public ConfirmYourIdentityPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeHomePage ConfirmIdentity()
        {
            EnterApprenticeDetails(apprenticeCommitmentsDataHelper.ApprenticeFirstname,
                apprenticeCommitmentsDataHelper.ApprenticeLastname,
                apprenticeCommitmentsDataHelper.DateOfBirthDay,
                apprenticeCommitmentsDataHelper.DateOfBirthMonth,
                apprenticeCommitmentsDataHelper.DateOfBirthYear,
                apprenticeCommitmentsDataHelper.NationalInsuranceNumber);
            return new ApprenticeHomePage(_context);
        }

        public ConfirmYourIdentityPage InvalidData(string firstname, string lastname, int? day, int? month, int? year, string nino)
        {
            EnterApprenticeDetails(firstname, lastname, day, month, year, nino);
            return this;
        }

        public void VerifyErrorSummary() => StringAssert.Contains("There is a problem", pageInteractionHelper.GetText(ErrorSummary), "Confirm Identity Page error message did not match");

        private void EnterApprenticeDetails(string firstname, string lastname, int? day, int? month, int? year, string nino)
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

            formCompletionHelper.EnterText(NationalInsuranceNumber, nino);
            Continue();
        }
    }
}
