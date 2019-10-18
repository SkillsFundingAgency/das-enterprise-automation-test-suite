using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourFundingReservationsPage : BasePage
    {
        protected override string PageTitle => "Your funding reservations";
        private By ReserveMoreFundingLink => By.LinkText("Reserve more funding");
        private By DeleteLink => By.LinkText("Delete");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public YourFundingReservationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ReserveFundingToTrainAndAssessAnApprenticePage ClickReserveMoreFundingLink()
        {
            _formCompletionHelper.ClickElement(ReserveMoreFundingLink);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
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
