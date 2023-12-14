using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ReviewChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Review changes";

        public ReviewChangesPage(ScenarioContext context) : base(context) { }

        protected override By ContinueButton => By.Id("continue-button");

        public EditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            Continue();
            return new EditedApprenticeDetailsPage(context);
        }

        public ApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "No");
            Continue();
            return new ApprenticeDetailsPage(context);
        }
    }
}