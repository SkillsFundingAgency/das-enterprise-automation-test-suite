using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourEmployerPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "Confirm your employer";

        protected override By ContinueButton => By.CssSelector("#employer-provider-confirm");

        public ConfirmYourEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage();
        }

        public ApprenticeHomePage SelectYes()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new ApprenticeHomePage(_context);
        }

        public YouCantConfirmYourApprenticeship SelectNo()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
            return new YouCantConfirmYourApprenticeship(_context);
        }
    }
}
