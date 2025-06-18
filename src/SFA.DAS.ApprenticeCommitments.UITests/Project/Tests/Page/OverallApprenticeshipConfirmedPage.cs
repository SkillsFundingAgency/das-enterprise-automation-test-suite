using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class OverallApprenticeshipConfirmedPage(ScenarioContext context) : ApprenticeCommitmentsBasePage(context)
    {
        protected override string PageTitle => "You have confirmed your apprenticeship details";
        protected static By TrainingName => By.CssSelector(".govuk-panel__body");

        public void NavigateBackToOverviewPage() => NavigateBack();

        public OverallApprenticeshipConfirmedPage VerifyTrainingNameOnGreenHeaderBoxOnTheOverallApprenticeshipConfirmedPage()
        {
            VerifyPage(() => pageInteractionHelper.FindElement(TrainingName), objectContext.GetExpectedTrainingTitles());
            return new OverallApprenticeshipConfirmedPage(context);
        }
    }
}
