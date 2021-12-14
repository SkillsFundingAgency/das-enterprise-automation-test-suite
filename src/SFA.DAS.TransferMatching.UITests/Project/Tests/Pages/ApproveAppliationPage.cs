using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApproveAppliationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ApproveAppliationPage(ScenarioContext context) : base(context) { }

        public ApprovingTheApprenticeshipDetailsPage GoToApprovingTheApprenticeshipDetailsPage()
        {
            SelectRadioOptionByText("Approve the application");
            Continue();
            return new ApprovingTheApprenticeshipDetailsPage(_context);
        }

        public TransferPledgePage RejectApplication()
        {
            SelectRadioOptionByText("Reject the application");
            Continue();
            return new TransferPledgePage(_context);
        }
    }
}
