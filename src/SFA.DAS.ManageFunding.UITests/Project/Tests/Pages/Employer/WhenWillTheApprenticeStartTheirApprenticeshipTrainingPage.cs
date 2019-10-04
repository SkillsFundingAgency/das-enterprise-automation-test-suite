using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer
{
    class WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage : BasePage
    {
        protected override string PageTitle => "When will the apprentice start their apprenticeship training?";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ManageFundingConfig _config;
        #endregion

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetManageFundingConfig<ManageFundingConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By MonthRadioButton => By.CssSelector(".govuk-radios__label");

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage ClickMonthRadioButton()
        {
            _formCompletionHelper.ClickElement(MonthRadioButton);
            return new WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(_context);
        }

        private By SaveAndContinueButton => By.CssSelector(".govuk-button");

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage ClickSaveAndContinueButton()
        {
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(_context);
        }
    }
}
