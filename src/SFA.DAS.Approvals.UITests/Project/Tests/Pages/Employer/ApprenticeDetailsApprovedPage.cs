using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsApprovedPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Apprentice details approved";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");

        public ApprenticeDetailsApprovedPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}