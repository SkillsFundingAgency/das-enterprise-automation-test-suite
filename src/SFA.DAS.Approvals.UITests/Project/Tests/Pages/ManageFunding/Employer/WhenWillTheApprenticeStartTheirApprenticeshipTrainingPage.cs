using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage : ApprovalsBasePage
    {
        protected override string PageTitle => "When will the apprentice start their apprenticeship training?";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage ClickMonthRadioButton()
        {
            formCompletionHelper.ClickElement(RadioLabels);
            return new WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(_context);
        }

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage ClickSaveAndContinueButton()
        {
            Continue();
            return new ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(_context);
        }
    }
}