using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage : BasePage
    {
        protected override string PageTitle => "When will the apprentice start their apprenticeship training?";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage ClickMonthRadioButton()
        {
            _formCompletionHelper.ClickElement(RadioLabels);
            return new WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(_context);
        }

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage ClickSaveAndContinueButton()
        {
            Continue();
            return new ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(_context);
        }
    }
}
