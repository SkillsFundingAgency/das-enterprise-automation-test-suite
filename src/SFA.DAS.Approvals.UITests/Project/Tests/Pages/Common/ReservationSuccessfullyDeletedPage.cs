using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class ReservationSuccessfullyDeletedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Reservation successfully deleted";

        protected override By PageHeader => By.CssSelector("h1.govuk-panel__title");

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ReservationSuccessfullyDeletedPage(ScenarioContext context) : base(context) => _context = context;

        public ApprovalsProviderHomePage GoToHomePage()
        {
            SelectRadioOptionByText("Go to homepage");
            Continue();
            return new ApprovalsProviderHomePage(_context);
        }
    }
}
