using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{

    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "";

        private readonly ScenarioContext _context;

        public ApprenticeHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }

    public class ConfirmYourIdentityPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Confirm your identity";

        private readonly ScenarioContext _context;

        private By FirstName => By.CssSelector("#FirstName");
        private By LastName => By.CssSelector("#LastName");
        private By DateOfBirth_Day => By.CssSelector("#DateOfBirth_Day");
        private By DateOfBirth_Month => By.CssSelector("#DateOfBirth_Month");
        private By DateOfBirth_Year => By.CssSelector("#DateOfBirth_Year");
        private By NationalInsuranceNumber => By.CssSelector("#NationalInsuranceNumber");

        protected override By ContinueButton => By.CssSelector("#identity-assurance-btn");

        public ConfirmYourIdentityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApprenticeHomePage ConfirmIdentity()
        {
            formCompletionHelper.EnterText(FirstName, objectContext.GetApprenticeEmail());
            formCompletionHelper.EnterText(LastName, apprenticeCommitmentsConfig.AC_AccountPassword);
            formCompletionHelper.EnterText(DateOfBirth_Day, apprenticeCommitmentsConfig.AC_AccountPassword);
            formCompletionHelper.EnterText(DateOfBirth_Month, apprenticeCommitmentsConfig.AC_AccountPassword);
            formCompletionHelper.EnterText(DateOfBirth_Year, apprenticeCommitmentsConfig.AC_AccountPassword);
            formCompletionHelper.EnterText(NationalInsuranceNumber, apprenticeCommitmentsConfig.AC_AccountPassword);
            Continue();
            return new ApprenticeHomePage(_context);
        }
    }

    public class SignIntoApprenticeshipPortalPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Sign in to Apprenticeship portal";

        private readonly ScenarioContext _context;

        private By Username => By.CssSelector("#Username");

        private By Password => By.CssSelector("#Password");

        public SignIntoApprenticeshipPortalPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmYourIdentityPage SignInToApprenticePortal()
        {
            formCompletionHelper.EnterText(Username, objectContext.GetApprenticeEmail());
            formCompletionHelper.EnterText(Password, apprenticeCommitmentsConfig.AC_AccountPassword);
            formCompletionHelper.ClickButtonByText(ContinueButton, "Sign in");
            return new ConfirmYourIdentityPage(_context);
        }
    }
}
