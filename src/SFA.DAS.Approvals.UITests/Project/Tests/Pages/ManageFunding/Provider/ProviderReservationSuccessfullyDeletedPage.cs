using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderReservationSuccessfullyDeletedPage : BasePage
    {
        protected override string PageTitle => "Reservation successfully deleted";

        protected override By PageHeader => By.CssSelector("h1.govuk-panel__title");

        public ProviderReservationSuccessfullyDeletedPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
