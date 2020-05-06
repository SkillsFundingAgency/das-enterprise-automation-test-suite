using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{

    public class ResumedApprenticeDetailsPage : ConfirmApprenticeStatus
    {
        protected override string PageTitle => "Apprenticeship resumed";
        protected override By PageHeader => By.CssSelector("h1.heading-large");

        public ResumedApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
        }
    }
}