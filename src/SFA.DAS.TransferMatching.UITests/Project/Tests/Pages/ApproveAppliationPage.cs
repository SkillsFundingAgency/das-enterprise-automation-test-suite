using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApproveAppliationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        private By EstimatedCostText => By.CssSelector("#main-content > div:nth-child(3) > p:nth-child(7)");
        private By ApproveDisclaimerText => By.CssSelector("#approval-content");

        public ApproveAppliationPage(ScenarioContext context) : base(context) { }

        public ApprovingTheApprenticeshipDetailsPage GoToApprovingTheApprenticeshipDetailsPage()
        {
            pageInteractionHelper.IsElementDisplayed(EstimatedCostText);
            SelectRadioOptionByText("Approve the application");
            pageInteractionHelper.IsElementDisplayed(ApproveDisclaimerText);
            Continue();
            return new ApprovingTheApprenticeshipDetailsPage(context);
        }

        public TransferPledgePage RejectApplication()
        {
            SelectRadioOptionByText("Reject the application");
            Continue();
            return new TransferPledgePage(context);
        }
    }
}
