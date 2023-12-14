using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class YouCantConfirmBasePage(ScenarioContext context) : ApprenticeCommitmentsBasePage(context)
    {
        private static By ReturnToApprenticeshipButton => By.CssSelector("button.govuk-button");

        public ApprenticeOverviewPage ReturnToApprenticeOverviewPage()
        {
            formCompletionHelper.ClickButtonByText(ReturnToApprenticeshipButton, $"{ServiceName} details");
            return new ApprenticeOverviewPage(context);
        }
    }
}
