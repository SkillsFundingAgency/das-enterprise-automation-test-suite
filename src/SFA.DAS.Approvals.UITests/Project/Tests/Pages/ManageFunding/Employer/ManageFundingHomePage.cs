using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ManageFundingHomePage : InterimManageFundingHomePage
    {
        private By ReserveFundingLink => By.LinkText("Reserve funding");
        private By ReserveMoreFundingLink => By.LinkText("Reserve more funding");
        private By DeleteLink => By.LinkText("Delete");

        public ManageFundingHomePage(ScenarioContext context, bool navigate) : base(context, navigate) => VerifyPage();

        public ReserveFundingToTrainAndAssessAnApprenticePage ClickReserveFundingButton()
        {
            if (pageInteractionHelper.IsElementPresent(ReserveFundingLink)) formCompletionHelper.ClickElement(ReserveFundingLink);
            
            if (pageInteractionHelper.IsElementPresent(ReserveMoreFundingLink)) formCompletionHelper.ClickElement(ReserveMoreFundingLink);

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
            formCompletionHelper.ClickElement(ReserveFundingLink);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }

        internal InterimFinanceHomePage GoToFinancePage() => new InterimFinanceHomePage(_context, true);
    }
}