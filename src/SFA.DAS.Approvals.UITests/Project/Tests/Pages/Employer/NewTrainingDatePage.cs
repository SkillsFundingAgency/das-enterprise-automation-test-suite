using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class NewTrainingDatePage(ScenarioContext context) : ConfirmApprenticeStatus(context)
    {
        protected override string PageTitle => "New planned training finish date confirmed";

        protected override By PageHeader => By.CssSelector("h1.govuk-panel__title");
    }
}