using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer
{
    class ReserveFundingToTrainAndAssessAnApprenticePage : BasePage
    {
        protected override string PageTitle => "Reserve funding to train and assess an apprentice";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ManageFundingConfig _config;
        #endregion

        public ReserveFundingToTrainAndAssessAnApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetManageFundingConfig<ManageFundingConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By ReserveFundingButton => By.LinkText("Reserve funding");

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickReserveFundingButton()
        {
            _formCompletionHelper.ClickElement(ReserveFundingButton);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }
    }
}
