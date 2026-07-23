using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class PaymentsPausedConfirmationPage(ScenarioContext context) : ConfirmApprenticeStatus(context)
    {
        protected override string PageTitle => "Payments paused";
        protected override By PageHeader => By.CssSelector("h1.govuk-panel__title");

        internal ApprenticeDetailsPage GoBackToLearnerDetailsPage()
        {
            formCompletionHelper.ClickLinkByText("View learner details");
            return new ApprenticeDetailsPage(context);
        }

    }
}