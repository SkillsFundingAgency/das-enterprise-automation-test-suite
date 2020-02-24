using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourFundingReservationsPage : FundingBasePage
    {
        protected override string PageTitle => "Your funding reservations";
        private By ReserveFundingFirstButton => By.LinkText("Reserve funding");
        private By ReserveFundingSecondButton => By.LinkText("Reserve funding");
        private By ReserveMoreFundingLink => By.LinkText("Reserve more funding");
        private By DeleteLink => By.LinkText("Delete");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public YourFundingReservationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
    
        public ReserveFundingToTrainAndAssessAnApprenticePage ClickReserveFundingButton()
        {
            if (_pageInteractionHelper.IsElementPresent(ReserveFundingFirstButton))
            {
                formCompletionHelper.ClickElement(ReserveFundingFirstButton);
            }
            
            if (_pageInteractionHelper.IsElementPresent(ReserveMoreFundingLink))
            {
                formCompletionHelper.ClickElement(ReserveMoreFundingLink);
            }
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickReserveMoreFundingLink()
        {
            ClickReserveFundingButton();
            formCompletionHelper.ClickElement(ReserveFundingSecondButton);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }

        public DeleteReservationPage DeleteUnusedFunding()
        {
            _formCompletionHelper.ClickElement(DeleteLink);
            return new DeleteReservationPage(_context);
        }
        
        public bool CheckIfDeleteLinkIsPresent()
        {
            if(_pageInteractionHelper.IsElementPresent(DeleteLink))
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
