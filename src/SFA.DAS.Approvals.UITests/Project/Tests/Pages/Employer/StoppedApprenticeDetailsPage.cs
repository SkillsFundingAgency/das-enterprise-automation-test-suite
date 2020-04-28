using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StoppedApprenticeDetailsPage : ConfirmApprenticeStatus
    {
        protected override string PageTitle => "Apprenticeship stopped";
        protected override By PageHeader => By.CssSelector("h1.heading-large");
        public StoppedApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
        }
    }
}