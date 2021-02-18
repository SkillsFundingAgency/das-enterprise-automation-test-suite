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

        protected override By ContinueButton => By.CssSelector("#identity-assurance-btn");

        public ConfirmYourIdentityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApprenticeHomePage ConfirmIdentity()
        {
            formCompletionHelper.EnterText(FirstName, apprenticeCommitmentsDataHelper.ApprenticeFirstname);
            formCompletionHelper.EnterText(LastName, apprenticeCommitmentsDataHelper.ApprenticeLastname);
            formCompletionHelper.EnterText(DateOfBirth_Day, apprenticeCommitmentsDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirth_Month, apprenticeCommitmentsDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirth_Year, apprenticeCommitmentsDataHelper.DateOfBirthYear);
            formCompletionHelper.EnterText(NationalInsuranceNumber, apprenticeCommitmentsDataHelper.NationalInsuranceNumber);
            Continue();
            return new ApprenticeHomePage(_context);
        }
    }
}
