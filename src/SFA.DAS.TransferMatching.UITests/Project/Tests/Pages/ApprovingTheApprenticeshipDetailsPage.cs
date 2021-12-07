using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApprovingTheApprenticeshipDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Approving the apprenticeship details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ApprovingTheApprenticeshipDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public AppliationApprovedPage ManuallyApproveApplication()
        {
            SelectRadioOptionByText("Automatically approve the apprenticeship details");
            Continue();
            return new AppliationApprovedPage(_context);
        }


    }
}


