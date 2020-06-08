using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsApprovedAndSentToTrainingProviderPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Apprentice details approved and sent to training provider";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");

        public ApprenticeDetailsApprovedAndSentToTrainingProviderPage(ScenarioContext context) : base(context) { }
    }
}