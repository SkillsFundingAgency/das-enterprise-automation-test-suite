using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class SetUpAnApprenticeshipForAnExistingEmployeePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Set up an apprenticeship for an existing employee";

        private By ClickReserveFunding => By.Id("reserve-funding");

        public SetUpAnApprenticeshipForAnExistingEmployeePage(ScenarioContext context) : base(context)  { }

        public ReserveFundingToTrainAndAssessAnApprenticePage YesContinueToReserveFunding()
        {
            formCompletionHelper.Click(ClickReserveFunding);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }
    }
}
