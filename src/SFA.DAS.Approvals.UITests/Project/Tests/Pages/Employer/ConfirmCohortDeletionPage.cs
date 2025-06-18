using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmCohortDeletionPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Confirm deletion";
        protected override By ContinueButton => By.Id("continue-button");

        public ApprenticeRequestsPage ConfirmDeleteAndSubmit()
        {
            SelectRadioOptionByForAttribute("confirm-yes");
            Continue();
            return new ApprenticeRequestsPage(context);
        }
    }
}
