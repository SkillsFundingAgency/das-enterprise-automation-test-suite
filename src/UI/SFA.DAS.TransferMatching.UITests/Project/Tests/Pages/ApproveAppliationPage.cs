using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApproveAppliationPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        protected override string AccessibilityPageTitle => "Approve applicaiton page";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        private static By EstimatedCostText => By.CssSelector("#main-content > div:nth-child(3) > p:nth-child(7)");
        private static By ApproveDisclaimerText => By.CssSelector("#approval-content");
        private static By DateAppliedSelector => By.LinkText("Date applied");

        public ApprovingTheApprenticeshipDetailsPage GoToApprovingTheApprenticeshipDetailsPage()
        {
            pageInteractionHelper.IsElementDisplayed(EstimatedCostText);
            pageInteractionHelper.IsElementDisplayed(DateAppliedSelector);
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
