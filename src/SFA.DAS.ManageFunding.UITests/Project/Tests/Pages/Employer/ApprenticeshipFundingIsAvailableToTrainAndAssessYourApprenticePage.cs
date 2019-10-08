using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage : BasePage
    {
        protected override string PageTitle => "Apprenticeship funding is available to train and assess your apprentice";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By YesReserveFundingNowRadioButton => By.CssSelector("label[for=Reserve]");

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage ClickYesReserveFundingNowRadioButton()
        {
            _formCompletionHelper.ClickElement(YesReserveFundingNowRadioButton);
            return new ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(_context);
        }

        private By ConfirmButton => By.CssSelector(".govuk-button");

        public MakingChangesPage ClickConfirmButton()
        {
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new MakingChangesPage(_context);
        }
    }
}
