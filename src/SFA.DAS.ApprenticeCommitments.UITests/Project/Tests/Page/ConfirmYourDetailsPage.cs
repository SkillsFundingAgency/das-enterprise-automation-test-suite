using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class ConfirmYourDetailsPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;

        public ConfirmYourDetailsPage(ScenarioContext context) : base(context)
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
