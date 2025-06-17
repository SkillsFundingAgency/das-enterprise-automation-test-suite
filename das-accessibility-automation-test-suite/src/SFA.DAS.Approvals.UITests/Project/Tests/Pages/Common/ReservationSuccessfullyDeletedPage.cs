using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class ReservationSuccessfullyDeletedPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Reservation successfully deleted";

        protected override By PageHeader => By.CssSelector("h1.govuk-panel__title");

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        internal ApprovalsProviderHomePage GoToHomePage()
        {
            SelectRadioOptionByText("Go to homepage");
            Continue();
            return new ApprovalsProviderHomePage(context);
        }
    }
}
