using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeDeletionPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Delete the apprentice";
        protected override By ContinueButton => By.Id("continue-button");

        internal ApproveApprenticeDetailsPage ConfirmDeleteAndSubmit()
        {
            SelectRadioOptionByForAttribute("confirmDelete-true");
            Continue();
            return new ApproveApprenticeDetailsPage(context);
        }
    }
}
