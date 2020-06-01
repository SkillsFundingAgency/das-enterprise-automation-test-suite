using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReserveFundingToTrainAndAssessAnApprenticePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Reserve funding to train and assess an apprentice";
        private By ReserveFundingButton => By.LinkText("Reserve funding");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ReserveFundingToTrainAndAssessAnApprenticePage(ScenarioContext context) : base(context) => _context = context;

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickReserveFundingButton()
        {
            formCompletionHelper.ClickElement(ReserveFundingButton);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }
    }
}