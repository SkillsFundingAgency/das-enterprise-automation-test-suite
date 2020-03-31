using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class ApprovalsDynamicHomePage : HomePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprovalsDynamicHomePage(ScenarioContext context) : base(context) => _context = context;
        
        public ReserveFundingToTrainAndAssessAnApprenticePage StartNowToReserveFunding()
        {
            formCompletionHelper.ClickElement(StartNowButton);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }
    }
}
