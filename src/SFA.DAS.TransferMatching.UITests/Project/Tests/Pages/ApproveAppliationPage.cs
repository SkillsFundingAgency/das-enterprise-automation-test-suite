using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApproveAppliationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        private By EstimatedCostText => By.LinkText("The estimated total cost of training is based on the funding band maximum, the planned start date of training and the 20% completion payment.");
        private By ApproveDisclaimerText => By.LinkText("You may wish to undertake your own in -house governance process before committing to fund a transfer.The receiving employer will provide you with their contact details as part of their application in order to do this. Before this is confirmed, you will need to choose how to approve the apprentice details on the next page.");

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
