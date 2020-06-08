using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class ReservationSuccessfullyDeletedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Reservation successfully deleted";

        protected override By PageHeader => By.CssSelector("h1.govuk-panel__title");

        public ReservationSuccessfullyDeletedPage(ScenarioContext context) : base(context) { }
    }
}
