using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class YouCantConfirmBasePage : ApprenticeCommitmentsBasePage
    {
        private By ReturnToApprenticeshipButton => By.CssSelector("button.govuk-button");

        public YouCantConfirmBasePage(ScenarioContext context) : base(context)  { }

        public ApprenticeOverviewPage ReturnToApprenticeOverviewPage()
        {
            formCompletionHelper.ClickButtonByText(ReturnToApprenticeshipButton, $"{ServiceName} details");
            return new ApprenticeOverviewPage(_context);
        }
    }
}
