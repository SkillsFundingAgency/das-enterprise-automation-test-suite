using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage : BasePage
    {
        protected override string PageTitle => "Apprenticeship funding is available to train and assess your apprentice";
        private By YesReserveFundingNowRadioButton => By.CssSelector("label[for=Reserve]");
        private By ConfirmButton => By.CssSelector("main button");

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

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage ClickYesReserveFundingNowRadioButton()
        {
            _formCompletionHelper.ClickElement(YesReserveFundingNowRadioButton);
            return new ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(_context);
        }

        public SuccessfullyReservedFundingPage ClickConfirmButton()
        {
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new SuccessfullyReservedFundingPage(_context);
        }
    }
}
