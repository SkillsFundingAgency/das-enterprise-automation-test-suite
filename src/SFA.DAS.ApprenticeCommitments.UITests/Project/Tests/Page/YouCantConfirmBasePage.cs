using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class YouCantConfirmBasePage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;

        private By ReturnToApprenticeshipButton => By.CssSelector("button.govuk-button");

        public YouCantConfirmBasePage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeHomePage ReturnToApprenticeHomePage()
        {
            formCompletionHelper.ClickButtonByText(ReturnToApprenticeshipButton, $"{ServiceName} details");
            return new ApprenticeHomePage(_context);
        }
    }
}
