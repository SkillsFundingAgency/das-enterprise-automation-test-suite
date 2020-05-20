using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ManageFundingHomePage : InterimManageFundingHomePage
    {
        private By ReserveFundingLink => By.LinkText("Reserve funding");
        private By ReserveMoreFundingLink => By.LinkText("Reserve more funding");
        private By DeleteLink => By.LinkText("Delete");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public ManageFundingHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
    
        public ReserveFundingToTrainAndAssessAnApprenticePage ClickReserveFundingButton()
        {
            if (_pageInteractionHelper.IsElementPresent(ReserveFundingLink))
            {
                formCompletionHelper.ClickElement(ReserveFundingLink);
            }
            
            if (_pageInteractionHelper.IsElementPresent(ReserveMoreFundingLink))
            {
                formCompletionHelper.ClickElement(ReserveMoreFundingLink);
            }
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }

        public DeleteReservationPage DeleteUnusedFunding()
        {
            _formCompletionHelper.ClickElement(DeleteLink);
            return new DeleteReservationPage(_context);
        }

        public bool CheckIfDeleteLinkIsPresent() => _pageInteractionHelper.IsElementPresent(DeleteLink);
        
        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickReserveMoreFundingLink()
        {
            ClickReserveFundingButton();
            formCompletionHelper.ClickElement(ReserveFundingLink);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }

        internal FinancePage GoToFinancePage() => new FinancePage(_context, true);
    }
}