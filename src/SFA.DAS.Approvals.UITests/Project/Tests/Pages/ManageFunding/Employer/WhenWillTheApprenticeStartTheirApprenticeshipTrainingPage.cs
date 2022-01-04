using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage : ApprovalsBasePage
    {
        protected override string PageTitle => "When will the apprentice start their apprenticeship training?";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(ScenarioContext context) : base(context)  { }

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage ClickMonthRadioButton()
        {
            formCompletionHelper.ClickElement(RadioLabels);
            return new WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(context);
        }

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage ClickSaveAndContinueButton()
        {
            Continue();
            return new ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(context);
        }
    }
}