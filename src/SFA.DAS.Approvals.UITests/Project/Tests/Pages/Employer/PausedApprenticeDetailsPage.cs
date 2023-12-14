using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class PausedApprenticeDetailsPage(ScenarioContext context) : ConfirmApprenticeStatus(context)
    {
        protected override string PageTitle => "Apprenticeship paused";

        protected override By PageHeader => By.CssSelector("h1.govuk-heading-xl");
    }
}