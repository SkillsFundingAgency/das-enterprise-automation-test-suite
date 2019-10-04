using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer
{
    class ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage : BasePage
    {
        protected override string PageTitle => "Apprenticeship funding is available to train and assess your apprentice";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ManageFundingConfig _config;
        #endregion

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetManageFundingConfig<ManageFundingConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By YesRadioButton => By.CssSelector("label[for=Reserve]");

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage ClickYesRadioButton()
        {
            _formCompletionHelper.ClickElement(YesRadioButton);
            return new ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(_context);
        }

        private By ConfirmButton => By.CssSelector(".govuk-button");

        public YouHaveSuccessfullyReservedFundingForApprenticeshipTrainingPage ClickConfirmButton()
        {
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new YouHaveSuccessfullyReservedFundingForApprenticeshipTrainingPage(_context);
        }
    }
}
