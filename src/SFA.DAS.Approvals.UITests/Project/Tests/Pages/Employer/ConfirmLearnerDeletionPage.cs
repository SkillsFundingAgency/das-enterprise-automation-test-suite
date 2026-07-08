using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmLearnerDeletionPage(ScenarioContext context, string learnerName = null) : ApprovalsBasePage(context)
    {
        private readonly string _learnerName = learnerName;

        protected override string PageTitle =>
            string.IsNullOrWhiteSpace(_learnerName)
                ? "Are you sure you want to delete the record for"
                : $"Are you sure you want to delete the record for {_learnerName}?";
        protected override By ContinueButton => By.Id("continue-button");

        internal ApproveLearnerDetailsPage ConfirmDeleteAndSubmit()
        {
            SelectRadioOptionByForAttribute("confirmDelete-true");
            Continue();
            return new ApproveLearnerDetailsPage(context);
        }
    }
}
