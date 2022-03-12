using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class OverallApprenticeshipConfirmedPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "You have confirmed your apprenticeship details";
        protected By TrainingName => By.CssSelector(".govuk-panel__body");

        public OverallApprenticeshipConfirmedPage(ScenarioContext context) : base(context) { }

        public void NavigateBackToOverviewPage() => NavigateBack();

        public OverallApprenticeshipConfirmedPage VerifyTrainingNameOnGreenHeaderBoxOnTheOverallApprenticeshipConfirmedPage()
        {
            Assert.AreEqual(objectContext.GetTrainingName().Split(',')[0].ToLower(), pageInteractionHelper.GetText(TrainingName).ToLower());
            return new OverallApprenticeshipConfirmedPage(context);
        }
    }
}
    