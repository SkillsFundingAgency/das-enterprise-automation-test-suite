using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class SetUpAnApprenticeshipForAnExistingEmployeePage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Set up an apprenticeship for an existing employee";

        private static By ClickReserveFunding => By.Id("reserve-funding");

        public ReserveFundingToTrainAndAssessAnApprenticePage YesContinueToReserveFunding()
        {
            formCompletionHelper.Click(ClickReserveFunding);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(context);
        }
    }
}
