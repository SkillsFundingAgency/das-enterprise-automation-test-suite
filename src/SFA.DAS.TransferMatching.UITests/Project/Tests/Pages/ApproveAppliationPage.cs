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

        public AppliationApprovedPage ApproveApplication()
        {
            SelectRadioOptionByText("Approve the application");
            Continue();
            return new AppliationApprovedPage(context);
        }
    }
}