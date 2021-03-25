using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class YouCantConfirmYourApprenticeship : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "You can’t confirm your apprenticeship yet";

        private By ReturnToApprenticeshipButton => By.CssSelector("button.govuk-button");

        public YouCantConfirmYourApprenticeship(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeHomePage ReturnToApprenticeHomePage()
        {
            formCompletionHelper.ClickButtonByText(ReturnToApprenticeshipButton, "Return to My Apprenticeship");
            return new ApprenticeHomePage(_context);
        }
    }
}
