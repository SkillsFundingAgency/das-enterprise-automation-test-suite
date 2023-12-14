using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApprovingTheApprenticeshipDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Approving the apprenticeship details";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ApprovingTheApprenticeshipDetailsPage(ScenarioContext context) : base(context) { }

        public AppliationApprovedPage ManuallyApproveApplication()
        {
            SelectRadioOptionByText("Check and review apprenticeship details");
            Continue();
            return new AppliationApprovedPage(context);
        }

        public AppliationApprovedPage AutoApproveApplication()
        {
            SelectRadioOptionByText("Automatically approve the apprenticeship details");
            Continue();
            return new AppliationApprovedPage(context);
        }
    }
}


