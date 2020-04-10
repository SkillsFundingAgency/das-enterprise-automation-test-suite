using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReserveFundingToTrainAndAssessAnApprenticePage : BasePage
    {
        protected override string PageTitle => "Reserve funding to train and assess an apprentice";
        private By ReserveFundingButton => By.LinkText("Reserve funding");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ReserveFundingToTrainAndAssessAnApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickReserveFundingButton()
        {
            _formCompletionHelper.ClickElement(ReserveFundingButton);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }
    }
}