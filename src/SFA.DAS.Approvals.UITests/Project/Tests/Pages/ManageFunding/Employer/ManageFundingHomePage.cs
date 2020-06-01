using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
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
        #endregion

        public ManageFundingHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            VerifyPage();
        }
    
        public ReserveFundingToTrainAndAssessAnApprenticePage ClickReserveFundingButton()
        {
            if (pageInteractionHelper.IsElementPresent(ReserveFundingLink))
            {
                base.formCompletionHelper.ClickElement(ReserveFundingLink);
            }
            
            if (pageInteractionHelper.IsElementPresent(ReserveMoreFundingLink))
            {
                base.formCompletionHelper.ClickElement(ReserveMoreFundingLink);
            }
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }

        public DeleteReservationPage DeleteUnusedFunding()
        {
            formCompletionHelper.ClickElement(DeleteLink);
            return new DeleteReservationPage(_context);
        }

        public bool CheckIfDeleteLinkIsPresent() => pageInteractionHelper.IsElementPresent(DeleteLink);
        
        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickReserveMoreFundingLink()
        {
            ClickReserveFundingButton();
            base.formCompletionHelper.ClickElement(ReserveFundingLink);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }

        internal FinancePage GoToFinancePage() => new FinancePage(_context, true);
    }
}