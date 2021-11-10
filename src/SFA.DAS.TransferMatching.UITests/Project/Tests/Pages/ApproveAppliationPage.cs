using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApproveAppliationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ApproveAppliationPage(ScenarioContext context) : base(context) => _context = context;

        public AppliationApprovedPage ApproveApplication()
        {
            SelectRadioOptionByText("Approve the application");
            Continue();
            return new AppliationApprovedPage(_context);
        }
    }
}